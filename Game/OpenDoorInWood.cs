using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInWood : MonoBehaviour
{
    public float distance = 3f;  // ������������ ���������� ��� �������������� � ������
    public float rotationSpeed = 2f; // �������� �������� �����

    public AudioSource lockeddoor;
    public AudioSource opendoor;

    public List<GameObject> doors;  // ������ ���� ������
    public List<GameObject> lockedDoors;  // ������ ���� �������� ������

    // ��������������� ����� ��� �������� ��������� ������ �����
    private class DoorState
    {
        public GameObject door;
        public bool isOpen;

        public DoorState(GameObject door)
        {
            this.door = door;
            isOpen = false;
        }
    }

    private List<DoorState> doorStates = new List<DoorState>();

    void Start()
    {
        // �������������� ��������� ��� ���� ������
        foreach (var door in doors)
        {
            doorStates.Add(new DoorState(door));
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ������� �� ��� ������ � ����� "DoorInWood" � ��������� �� �� � �������� ����������
            if (Physics.Raycast(ray, out hit, distance) && hit.transform.CompareTag("DoorInWood"))
            {
                // ���������, �� ������������� �� �����
                if (lockedDoors.Contains(hit.transform.gameObject))
                {
                    lockeddoor.Play();
                }

                foreach (var doorState in doorStates)
                {
                    if (doorState.door == hit.transform.gameObject)
                    {
                        opendoor.Play();
                        StartCoroutine(RotateDoor(doorState)); // ��������� ��� ��������� �����
                        return;
                    }
                }
            }
        }
    }

    private IEnumerator RotateDoor(DoorState doorState)
    {
        float initialRotationY = doorState.door.transform.eulerAngles.y; // ��������� ������� �� Y
        float targetRotationY;

        // ���������� ����������� �������� ����� (�������� ��� ��������)
        targetRotationY = doorState.isOpen ? initialRotationY - 90f : initialRotationY + 90f;

        // ������� ������� �����
        Quaternion startRotation = doorState.door.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(doorState.door.transform.eulerAngles.x, targetRotationY, doorState.door.transform.eulerAngles.z);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed;
            doorState.door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        // ��������� ������ �������� �������� �������
        doorState.door.transform.rotation = endRotation;

        // ������ ��������� ����� �� ���������������
        doorState.isOpen = !doorState.isOpen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInBathroom : MonoBehaviour
{
    public List<GameObject> leftSideDoors;  // ����� � ����� �������, ������������� ������
    public List<GameObject> rightSideDoors; // ����� � ������ �������, ������������� ������
    public float rotationSpeed = 2f; // �������� �������� �����
    public float distance = 3f; // ������������ ��������� ��� ��������������

    // ��������������� ����� ��� �������� ��������� ������ �����
    private class DoorState
    {
        public GameObject door;
        public bool isOpen;

        public Quaternion initialRotation;

        public DoorState(GameObject door)
        {
            this.door = door;
            isOpen = false;
            initialRotation = door.transform.rotation;
        }
    }

    private List<DoorState> leftSideDoorStates = new List<DoorState>();
    private List<DoorState> rightSideDoorStates = new List<DoorState>();

    void Start()
    {
        // �������������� ��������� ��� ������ � ����� ������� (������)
        foreach (var door in leftSideDoors)
        {
            leftSideDoorStates.Add(new DoorState(door));
        }

        // �������������� ��������� ��� ������ � ������ ������� (������)
        foreach (var door in rightSideDoors)
        {
            rightSideDoorStates.Add(new DoorState(door));
        }
    }

    void Update()
    {
        // ���������, ���� �� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������� ������ ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ������� �� ��� ������ � ����� "Bathroom_toilet_door"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Bathroom_toilet_door"))
                {
                    // ��������� ����� � ����� �������
                    foreach (var doorState in leftSideDoorStates)
                    {
                        if (doorState.door == hit.transform.gameObject)
                        {
                            StartCoroutine(RotateDoor(doorState, true)); // ��������� ��� ��������� �����
                            break;
                        }
                    }

                    // ��������� ����� � ������ �������
                    foreach (var doorState in rightSideDoorStates)
                    {
                        if (doorState.door == hit.transform.gameObject)
                        {
                            StartCoroutine(RotateDoor(doorState, false)); // ��������� ��� ��������� �����
                            break;
                        }
                    }
                }
            }
        }
    }

    // �������� ��� �������� �����
    private IEnumerator RotateDoor(DoorState doorState, bool openOutwards)
    {
        float targetRotationY;

        if (openOutwards)
        {
            // �������� ������
            targetRotationY = doorState.isOpen ? doorState.initialRotation.eulerAngles.y : doorState.initialRotation.eulerAngles.y + 70f;
        }
        else
        {
            // �������� ������
            targetRotationY = doorState.isOpen ? doorState.initialRotation.eulerAngles.y : doorState.initialRotation.eulerAngles.y - 70f;
        }

        Quaternion startRotation = doorState.door.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(doorState.initialRotation.eulerAngles.x, targetRotationY, doorState.initialRotation.eulerAngles.z);

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

using UnityEngine;
using System.Collections;

public class OpenCloseOfficeDoor : MonoBehaviour
{
    public float distance = 3f;
    public Transform doorTransform; // ��������� �����
    public Transform targetPoint1; // ������� ��� �������� �����
    public Transform targetPoint2; // ������� ��� �������� �����
    public float moveSpeed = 10f; // �������� �������� �����

    public GameObject Button; // ������ ������
    public AudioSource Door; // �������� �������� ��� �����

    private bool isOpen = false; // ��������� �����
    //private bool isInteracting = false; // ���� ��� ������������ �������������� � ������

    public void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            // ���������, ��� ������ ������ � ��� ������� ��� ��������������
            if (hit.transform.gameObject == Button)
            {
                //isInteracting = true; // ������������� ���� ��������������

                // ��������� ��������� ����� ����� �������������
                if (isOpen)
                {
                    Door.Play();
                    MoveDoorToTargetDown(targetPoint2.position);
                }
                else
                {
                    Door.Play();
                    MoveDoorToTargetUp(targetPoint1.position);
                }

                isOpen = !isOpen; // ����������� ��������� �����

                // ����� ���������� �������� ���������� ���� ��������������
                StartCoroutine(ResetInteraction());
            }
        }
    }

    private void MoveDoorToTargetUp(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    private void MoveDoorToTargetDown(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    private IEnumerator MoveDoorCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(doorTransform.position, targetPosition) > 0.01f)
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        doorTransform.position = targetPosition;
    }

    private IEnumerator ResetInteraction()
    {
        // ���, ���� ����� �� ��������� ������� �������
        while (Vector3.Distance(doorTransform.position, isOpen ? targetPoint1.position : targetPoint2.position) > 0.01f)
        {
            yield return null;
        }
        //isInteracting = false; // ���������� ���� ��������������
    }
}

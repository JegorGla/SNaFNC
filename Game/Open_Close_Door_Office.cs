using UnityEngine;
using System.Collections;

public class OpenCloseDoorOffice : MonoBehaviour
{
    public float distance = 3f; // ������������ ��������� ��� �������������� � ������
    public Transform doorTransform; // ������ �� Transform ������� �����
    public Transform targetPoint1; // ������ ������, � �������� ������������ ����� �����
    public Transform targetPoint2; // ������ ������, � �������� ������������ ����� ����
    public float moveSpeed = 10f; // �������� ����������� ����� � ������� �����

    public AudioSource Door;

    private bool isOpen = false; // ������� ���������� ��� ������������ ��������� �����

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.CompareTag("Button")) // ���������, ��� ������ ������ � �����
            {
                isOpen = !isOpen; // ����������� ��������� ����� ����� ���������� ��������

                if (isOpen)
                {
                    Door.Play();
                    MoveDoorToTargetUp(targetPoint1.position); // ��������� ����������� ����� � ������� ����� �����
                }
                else
                {
                    Door.Play();
                    MoveDoorToTargetDown(targetPoint2.position); // ��������� ����������� ����� � ������� ����� ����
                }
            }
        }
    }

    void MoveDoorToTargetUp(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    void MoveDoorToTargetDown(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    IEnumerator MoveDoorCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(doorTransform.position, targetPosition) > 0.01f)
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        doorTransform.position = targetPosition;
    }
}

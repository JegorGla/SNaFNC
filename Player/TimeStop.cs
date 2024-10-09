using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public GameObject Player; // ������ ������
    public float stopDuration = 10f; // ������������ ��������� �������

    private List<Rigidbody> affectedRigidbodies = new List<Rigidbody>(); // ������ �������� � �������
    private List<Animator> affectedAnimators = new List<Animator>(); // ������ �������� � ���������

    public void StopTime()
    {
        StartCoroutine(TimeStopCoroutine());
    }

    private IEnumerator TimeStopCoroutine()
    {
        // �������� ��� ������� � �����
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // ���������� ��� �������
        foreach (GameObject obj in allObjects)
        {
            if (obj == Player || obj.transform.IsChildOf(Player.transform))
            {
                continue;
            }

            // ��������� ������
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                affectedRigidbodies.Add(rb);
            }

            // ��������� ��������
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
                affectedAnimators.Add(animator);
            }
        }

        // ���� ��������� �����
        yield return new WaitForSecondsRealtime(stopDuration);

        // ������������ ������ � ��������
        foreach (Rigidbody rb in affectedRigidbodies)
        {
            rb.isKinematic = false;
        }
        affectedRigidbodies.Clear();

        foreach (Animator animator in affectedAnimators)
        {
            animator.enabled = true;
        }
        affectedAnimators.Clear();
    }
}

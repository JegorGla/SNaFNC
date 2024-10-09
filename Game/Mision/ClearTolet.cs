using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearToilet : MonoBehaviour
{
    public float distance = 3f;
    private float needToClean = 16f;
    private float cleanedCount = 0f;

    public Text ilosc;
    public Text ClearToiletText;

    public AudioSource Smytije;

    void Update()
    {
        // ���������, ���� �� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������� ������ ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ������� �� ��� ������ � ����� "Toilet"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Toilet"))
                {
                    Smytije.Play();
                    cleanedCount += 1f;

                    // ��������� ����� � ����������� ��������� ��������
                    ilosc.text = $"{cleanedCount}/{needToClean}";

                    // ��������� �������������� � ���� ��������, ����� �� ������� ��� ��������
                    hit.transform.gameObject.tag = "Untagged";

                    // ���� ��� ������� �������, ����� ��������� �������������� ��������
                    if (cleanedCount >= needToClean)
                    {
                        // ��������, ������� �����-������ ����� ��� ���������� ���������
                        ilosc.color = Color.green;
                        ClearToiletText.color = Color.green;
                    }
                }
            }
        }
    }
}

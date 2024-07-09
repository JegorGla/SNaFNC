using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreddaCamera : MonoBehaviour
{
    public float decreaseRate = 0.1f; // �������� ���������� �������� � ��������� � �������
    private float overdriveValue = 100f; // ��������� �������� ��������
    public Image nakrutka;

    // ������� ���������� ��� ��������� ������
    public bool isCameraActive = false;

    void Start()
    {
        if (nakrutka != null)
        {
            nakrutka.fillAmount = overdriveValue / 100f;
            nakrutka.gameObject.SetActive(false); // �������� �������� ��� ������
        }
    }

    void Update()
    {
        if (isCameraActive)
        {
            // �������� ��������, ���� ������ �������
            if (nakrutka != null && !nakrutka.gameObject.activeSelf)
            {
                nakrutka.gameObject.SetActive(true);
            }

            if (overdriveValue > 0)
            {
                overdriveValue -= decreaseRate * Time.deltaTime;
                overdriveValue = Mathf.Clamp(overdriveValue, 0, 100); // ��������, ��� �������� �� ������� �� ������� 0-100

                // ��������� �������� ���������� �����������
                if (nakrutka != null)
                {
                    nakrutka.fillAmount = overdriveValue / 100f; // �������� �������� � ��������� 0-1
                }
            }
        }
        else
        {
            // ������ ��������, ���� ������ �� �������
            if (nakrutka != null && nakrutka.gameObject.activeSelf)
            {
                nakrutka.gameObject.SetActive(false);
            }
        }
    }

    // ����� ��� ���������/���������� ������
    public void SetCameraActive(bool isActive)
    {
        isCameraActive = isActive;
    }
}

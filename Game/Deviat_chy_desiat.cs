using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devyat_chy_Desiat : MonoBehaviour
{
    public GameObject old_phone;
    public Camera Camera;
    public AudioSource Mem;

    private bool isCall;

    private void Start()
    {
        Mem = GetComponent<AudioSource>();
        isCall = false;
    }

    private void Update()
    {
        // ���������, ������ �� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������ � ����� �� ������, �� ������� ��������� ����
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ������������ �� ��� � �����-���� ��������
            if (Physics.Raycast(ray, out hit))
            {
                // ���������, ������������ �� ��� � old_phone � ����� �� ������ ���������� ���
                if (hit.transform.CompareTag("Old_Phone"))
                {
                    if (!isCall)
                    {
                        Mem.Play();
                        isCall = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Mem.Stop();
                    }
                }
            }
        }
    }
}

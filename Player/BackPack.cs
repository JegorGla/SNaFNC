using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour
{
    public GameObject Button;
    public GameObject[] objectForPokaza; // ������ �������� ��� ������
    public GameObject VinoObject;
    public GameObject VinoImage; // ������ ��� ����������� ����

    public GameObject StopTime;

    public AudioSource Zasterhka; // �������������
    public GameObject PolishCow;

    private void Start()
    {
        StopTime.SetActive(false);
        Button.SetActive(false);
        VinoImage.gameObject.SetActive(false); // �������� ����������� ����

        Zasterhka = GetComponent<AudioSource>();
    }

    public void Update()
    {
        // ���� ������ ������� Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���������� ��� ������� �� �������
            foreach (GameObject obj in objectForPokaza)
            {
                obj.SetActive(true);
            }

            Button.SetActive(true);
            StopTime.SetActive(true);

            // ���� ������ Vino ��� ��������� (VinoObject = null), ���������� �����������
            if (VinoObject == null)
            {
                VinoImage.SetActive(true);
            }

            // ���������� ������
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            // ������������� ���� ��������
            Zasterhka.Play();
        }
        // ���� ������� Space ��������
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            PolishCow.SetActive(false);
            foreach (GameObject obj in objectForPokaza)
            {
                obj.SetActive(false);
            }

            StopTime.SetActive(false);
            Button.SetActive(false);

            // �������� ������
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // ������������� ���� ��������
            Zasterhka.Play();
        }
    }

    public void SeePomocnika()
    {
        
        PolishCow.SetActive(true);
    }
    // ����� ��� ��������� ����
    //public void ActivateVino()
    //{
    //    VinoImage.SetActive(false); // �������� ����������� ����
    //}
}

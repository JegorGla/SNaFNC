using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMEME : MonoBehaviour
{
    public Button OnMusic;
    public Button OffMusic;

    public GameObject Info;
    void Start()
    {
        Info.SetActive(false);
        // ��������������� ��������� ������ ��� �������
        if (PlayerPrefs.HasKey("MusicState"))
        {
            int musicState = PlayerPrefs.GetInt("MusicState");

            if (musicState == 1) // 1 - ������ ��������
            {
                OnMusic.gameObject.SetActive(true);
                OffMusic.gameObject.SetActive(false);
            }
            else // 0 - ������ ���������
            {
                OnMusic.gameObject.SetActive(false);
                OffMusic.gameObject.SetActive(true);
            }
        }
        else
        {
            // �� ��������� ������ ���������
            OffMusic.gameObject.SetActive(true);
        }
    }

    // ����� ��� ��������� ������
    public void OnMusicmeme()
    {
        OnMusic.gameObject.SetActive(true);
        OffMusic.gameObject.SetActive(false);

        // ��������� ��������� (1 - ������ ��������)
        PlayerPrefs.SetInt("MusicState", 1);
        PlayerPrefs.Save();
    }

    // ����� ��� ���������� ������
    public void OffMusicmeme()
    {
        OffMusic.gameObject.SetActive(true);
        OnMusic.gameObject.SetActive(false);

        // ��������� ��������� (0 - ������ ���������)
        PlayerPrefs.SetInt("MusicState", 0);
        PlayerPrefs.Save();
    }

    public void SeeInfoAboutThis()
    {
        Info.SetActive(true);
    }
   
    public void CloseInfo()
    {
        Info.SetActive(false);
    }
}

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
        // Восстанавливаем состояние кнопки при запуске
        if (PlayerPrefs.HasKey("MusicState"))
        {
            int musicState = PlayerPrefs.GetInt("MusicState");

            if (musicState == 1) // 1 - музыка включена
            {
                OnMusic.gameObject.SetActive(true);
                OffMusic.gameObject.SetActive(false);
            }
            else // 0 - музыка выключена
            {
                OnMusic.gameObject.SetActive(false);
                OffMusic.gameObject.SetActive(true);
            }
        }
        else
        {
            // По умолчанию музыка выключена
            OffMusic.gameObject.SetActive(true);
        }
    }

    // Метод для включения музыки
    public void OnMusicmeme()
    {
        OnMusic.gameObject.SetActive(true);
        OffMusic.gameObject.SetActive(false);

        // Сохраняем состояние (1 - музыка включена)
        PlayerPrefs.SetInt("MusicState", 1);
        PlayerPrefs.Save();
    }

    // Метод для выключения музыки
    public void OffMusicmeme()
    {
        OffMusic.gameObject.SetActive(true);
        OnMusic.gameObject.SetActive(false);

        // Сохраняем состояние (0 - музыка выключена)
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

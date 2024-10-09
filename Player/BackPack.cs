using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour
{
    public GameObject Button;
    public GameObject[] objectForPokaza; // Массив объектов для показа
    public GameObject VinoObject;
    public GameObject VinoImage; // Объект для изображения вина

    public GameObject StopTime;

    public AudioSource Zasterhka; // Аудиоисточник
    public GameObject PolishCow;

    private void Start()
    {
        StopTime.SetActive(false);
        Button.SetActive(false);
        VinoImage.gameObject.SetActive(false); // Скрываем изображение вина

        Zasterhka = GetComponent<AudioSource>();
    }

    public void Update()
    {
        // Если нажата клавиша Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Показываем все объекты из массива
            foreach (GameObject obj in objectForPokaza)
            {
                obj.SetActive(true);
            }

            Button.SetActive(true);
            StopTime.SetActive(true);

            // Если объект Vino был уничтожен (VinoObject = null), показываем изображение
            if (VinoObject == null)
            {
                VinoImage.SetActive(true);
            }

            // Показываем курсор
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            // Воспроизводим звук застежки
            Zasterhka.Play();
        }
        // Если клавиша Space отпущена
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            PolishCow.SetActive(false);
            foreach (GameObject obj in objectForPokaza)
            {
                obj.SetActive(false);
            }

            StopTime.SetActive(false);
            Button.SetActive(false);

            // Скрываем курсор
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Воспроизводим звук застежки
            Zasterhka.Play();
        }
    }

    public void SeePomocnika()
    {
        
        PolishCow.SetActive(true);
    }
    // Метод для активации вина
    //public void ActivateVino()
    //{
    //    VinoImage.SetActive(false); // Скрываем изображение вина
    //}
}

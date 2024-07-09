using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour
{
    public GameObject Button;
    public GameObject Vino;
    public GameObject VinoObject;
    public Image VinoImage; // Добавьте Image компонент для отображения спрайта

    private void Start()
    {
        Button.SetActive(false);
        Vino.SetActive(false);
        VinoImage.gameObject.SetActive(false); // Скрыть изображение
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Button.SetActive(true);
            if (VinoObject == null) // Check if Vino has been destroyed
            {
                Vino.SetActive(true);
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Button.SetActive(false);
            Vino.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void AddItemToBackPack(Sprite itemSprite)
    {
        VinoImage.sprite = itemSprite;
        VinoImage.gameObject.SetActive(true);
    }

    public void ActivateVino()
    {
        Vino.SetActive(false);
    }
}

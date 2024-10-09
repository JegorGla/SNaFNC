using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeVino : MonoBehaviour
{
    public float distance = 3f; // Дистанция, на которой игрок может взаимодействовать с объектом
    public Sprite sprite; // Спрайт для инвентаря
    public Invertar invertar; // Ссылка на скрипт инвентаря
    public Text text; // Поле текста для отображения количества предметов
    private int Vinofloat = 0; // Текущее количество предметов в инвентаре
    private const int maxVino = 7; // Максимальное количество предметов в инвентаре

    private void Start()
    {
        DeactivateImage();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance) && hit.transform.CompareTag("Vino"))
            {
                CollectVino(hit.transform.gameObject);
            }
        }
    }

    public void CollectVino(GameObject vino)
    {
        if (Vinofloat < maxVino)
        {
            if (invertar != null && sprite != null)
            {
                int itemIndex = invertar.GetItemIndex(sprite);
                if (itemIndex != -1)
                {
                    UpdateItemCount(itemIndex); // Увеличиваем количество предмета
                }
                else
                {
                    invertar.AddItemToInventory(sprite); // Добавляем новый предмет в инвентарь
                    Vinofloat++;
                    text.text = Vinofloat.ToString(); // Устанавливаем количество
                    ActivateImage(); // Активируем изображение для отображения
                }
            }

            vino.SetActive(false);
        }
        else
        {
            Debug.Log("Инвентарь полон!");
        }
    }

    private void UpdateItemCount(int itemIndex)
    {
        Vinofloat++; // Увеличиваем количество в инвентаре
        text.text = Vinofloat.ToString(); // Обновляем текст
    }

    private void ActivateImage()
    {
        // Ваш код для активации изображения
    }

    private void DeactivateImage()
    {
        // Ваш код для деактивации изображения
    }
}

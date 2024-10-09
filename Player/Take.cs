using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // Дистанция, на которой игрок может взаимодействовать с объектом
    public Invertar invertar; // Ссылка на скрипт инвентаря

    public Image[] ImageForTake; // Массив изображений для предметов

    private void Start()
    {
        DeactivateAllImages(); // Деактивируем все изображения при старте
    }

    public void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч от камеры в направлении мыши
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Проверяем, попал ли луч в объект
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Vino"))
                {
                    // Получаем объект
                    GameObject vino = hit.transform.gameObject;
                    // Получаем спрайт из компонента SpriteRenderer
                    Sprite vinoSprite = vino.GetComponent<SpriteRenderer>().sprite;
                    vino.SetActive(false); // Деактивируем объект сразу после сбора

                    // Добавляем в инвентарь
                    invertar.AddItemToInventory(vinoSprite); // Добавляем спрайт в инвентарь

                    ActivateImage(vinoSprite); // Активируем изображение
                }

                if (hit.transform.CompareTag("Cleaner")) // Замените "Button" на "Cleaner"
                {
                    // Получаем объект
                    GameObject cleaner = hit.transform.gameObject;
                    // Получаем спрайт из компонента SpriteRenderer
                    Sprite cleanerSprite = cleaner.GetComponent<SpriteRenderer>().sprite;
                    cleaner.SetActive(false); // Деактивируем объект сразу после сбора

                    // Добавляем в инвентарь
                    invertar.AddItemToInventory(cleanerSprite); // Добавляем спрайт в инвентарь

                    ActivateImage(cleanerSprite); // Активируем изображение
                }
            }
        }
    }

    public void ActivateImage(Sprite itemSprite)
    {
        // Активируем изображение для соответствующего предмета
        for (int i = 0; i < ImageForTake.Length; i++)
        {
            if (ImageForTake[i].sprite == itemSprite)
            {
                ImageForTake[i].gameObject.SetActive(true);
                break; // Прерываем цикл после активации
            }
        }
    }

    public void DeactivateAllImages()
    {
        // Деактивируем все изображения в массиве
        for (int i = 0; i < ImageForTake.Length; i++)
        {
            ImageForTake[i].gameObject.SetActive(false);
        }
    }
}

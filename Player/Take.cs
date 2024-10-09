using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // Дистанция, на которой игрок может взаимодействовать с объектом
    public Invertar invertar; // Ссылка на скрипт инвентаря

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
                }

                if (hit.transform.CompareTag("Button"))
                {
                    // Получаем объект
                    GameObject cleaner = hit.transform.gameObject;
                    // Получаем спрайт из компонента SpriteRenderer
                    Sprite cleanerSprite = cleaner.GetComponent<SpriteRenderer>().sprite;
                    cleaner.SetActive(false); // Деактивируем объект сразу после сбора

                    // Добавляем в инвентарь
                    invertar.AddItemToInventory(cleanerSprite); // Добавляем спрайт в инвентарь
                }
            }
        }
    }
}

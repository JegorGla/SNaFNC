using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // Дистанция, на которой игрок может взаимодействовать с объектом
    public Image[] ImageForTake; // Массив изображений для отображения при подборе предмета
    public Sprite[] sprites; // Массив спрайтов для инвентаря
    public Invertar invertar; // Ссылка на скрипт инвентаря

    private void Start()
    {
        // Деактивируем все изображения в массиве ImageForTake
        DeactivateImages();
    }

    public void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч от камеры в направлении мыши
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Проверяем, попал ли луч в объект с тегами "Vino" или "Butt"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Vino"))
                {
                    TakeVino();
                }
                else if (hit.transform.CompareTag("Button"))
                {
                    TakeButt();
                }
            }
        }
    }

    private void TakeVino()
    {
        ActivateImages();
        if (invertar != null && sprites.Length > 0)
        {
            invertar.AddItemToInventory(sprites[0]); // Добавляем первый спрайт из массива
        }
    }

    private void TakeButt()
    {
        ActivateImages();
        if (invertar != null && sprites.Length > 1)
        {
            invertar.AddItemToInventory(sprites[1]); // Добавляем второй спрайт из массива
        }
    }

    private void ActivateImages()
    {
        // Активируем все изображения в массиве ImageForTake
        if (ImageForTake != null)
        {
            foreach (var image in ImageForTake)
            {
                if (image != null)
                {
                    image.gameObject.SetActive(true);
                }
            }
        }
    }

    private void DeactivateImages()
    {
        // Деактивируем все изображения в массиве ImageForTake
        if (ImageForTake != null)
        {
            foreach (var image in ImageForTake)
            {
                if (image != null)
                {
                    image.gameObject.SetActive(false);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearToilet : MonoBehaviour
{
    public float distance = 3f;
    private float needToClean = 16f;
    private float cleanedCount = 0f;

    public Text ilosc;
    public Text ClearToiletText;

    public AudioSource Smytije;

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из позиции камеры вперед
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, пересек ли луч объект с тегом "Toilet"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Toilet"))
                {
                    Smytije.Play();
                    cleanedCount += 1f;

                    // Обновляем текст с количеством очищенных туалетов
                    ilosc.text = $"{cleanedCount}/{needToClean}";

                    // Отключаем взаимодействие с этим туалетом, чтобы не считать его повторно
                    hit.transform.gameObject.tag = "Untagged";

                    // Если все туалеты очищены, можно выполнить дополнительные действия
                    if (cleanedCount >= needToClean)
                    {
                        // Например, вызвать какой-нибудь метод или отображать сообщение
                        ilosc.color = Color.green;
                        ClearToiletText.color = Color.green;
                    }
                }
            }
        }
    }
}

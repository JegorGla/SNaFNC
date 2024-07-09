using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreddaCamera : MonoBehaviour
{
    public float decreaseRate = 0.1f; // Скорость уменьшения накрутки в процентах в секунду
    private float overdriveValue = 100f; // Начальное значение накрутки
    public Image nakrutka;

    // Добавим переменную для состояния камеры
    public bool isCameraActive = false;

    void Start()
    {
        if (nakrutka != null)
        {
            nakrutka.fillAmount = overdriveValue / 100f;
            nakrutka.gameObject.SetActive(false); // Скрываем накрутку при старте
        }
    }

    void Update()
    {
        if (isCameraActive)
        {
            // Показать накрутку, если камера активна
            if (nakrutka != null && !nakrutka.gameObject.activeSelf)
            {
                nakrutka.gameObject.SetActive(true);
            }

            if (overdriveValue > 0)
            {
                overdriveValue -= decreaseRate * Time.deltaTime;
                overdriveValue = Mathf.Clamp(overdriveValue, 0, 100); // Убедимся, что значение не выходит за пределы 0-100

                // Обновляем значение заполнения изображения
                if (nakrutka != null)
                {
                    nakrutka.fillAmount = overdriveValue / 100f; // Приводим значение к диапазону 0-1
                }
            }
        }
        else
        {
            // Скрыть накрутку, если камера не активна
            if (nakrutka != null && nakrutka.gameObject.activeSelf)
            {
                nakrutka.gameObject.SetActive(false);
            }
        }
    }

    // Метод для включения/выключения камеры
    public void SetCameraActive(bool isActive)
    {
        isCameraActive = isActive;
    }
}

using System.Collections;
using UnityEngine;

public class ButtonInOfficeMaterialSetting : MonoBehaviour
{
    public Material closedButtonMaterial; // Материал для закрытой кнопки
    public Material openedButtonMaterial; // Материал для открытой кнопки

    public Renderer Button1;
    public Renderer Button2;

    private float interactionDistance = 3f;

    // Состояния кнопок
    private bool isButton1Open = false;
    private bool isButton2Open = false;

    void Start()
    {
        // Устанавливаем изначальный материал для кнопок
        Button1.material = closedButtonMaterial;
        Button2.material = closedButtonMaterial;
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Проверяем, есть ли у объекта коллайдер и какой объект был нажат
            if (hit.collider != null)
            {
                // Проверяем, на какую кнопку нажали
                if (hit.transform == Button1.transform)
                {
                    // Переключаем состояние кнопки 1
                    isButton1Open = !isButton1Open;
                    Button1.material = isButton1Open ? openedButtonMaterial : closedButtonMaterial;

                    // Закрываем кнопку 2, если она была открыта
                    if (isButton2Open)
                    {
                        isButton2Open = false;
                        Button2.material = closedButtonMaterial;
                    }
                }
                else if (hit.transform == Button2.transform)
                {
                    // Переключаем состояние кнопки 2
                    isButton2Open = !isButton2Open;
                    Button2.material = isButton2Open ? openedButtonMaterial : closedButtonMaterial;

                    // Закрываем кнопку 1, если она была открыта
                    if (isButton1Open)
                    {
                        isButton1Open = false;
                        Button1.material = closedButtonMaterial;
                    }
                }
            }
        }
    }
}

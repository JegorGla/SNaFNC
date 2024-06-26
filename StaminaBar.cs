using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Walk player; // Ссылка на скрипт игрока (изменено на PlayerController)
    public Image staminaBarImage; // Ссылка на изображение стамины

    void Update()
    {
        // Рассчитываем текущий процент стамины
        float staminaPercentage = player.CurrentStamina / player.stamina;

        // Устанавливаем размер столбика стамины
        staminaBarImage.fillAmount = staminaPercentage;
    }
}

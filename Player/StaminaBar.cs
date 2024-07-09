using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Walk player; // ������ �� ������ ������ (�������� �� PlayerController)
    public Image staminaBarImage; // ������ �� ����������� �������

    void Update()
    {
        // ������������ ������� ������� �������
        float staminaPercentage = player.CurrentStamina / player.stamina;

        // ������������� ������ �������� �������
        staminaBarImage.fillAmount = staminaPercentage;
    }
}

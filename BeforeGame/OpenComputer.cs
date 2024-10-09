using Unity.VisualScripting;
using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject ComputerCanvas;

    public Animator OpenComp; // Аниматор для открытия компьютера
    public Animator CloseComp; // Аниматор для закрытия компьютера

    private void Start()
    {
        // Начальное состояние: интерфейс компьютера, кнопка выхода и затемнение выключены
        ComputerCanvas.SetActive(false);

        // Получаем ссылки на аниматоры, прикрепленные к этому объекту
        OpenComp = GetComponent<Animator>();
        CloseComp = GetComponent<Animator>();

    }

    public void openComputer()
    {
        // Запускаем анимацию открытия компьютера
        OpenComp.SetTrigger("Field_screen");
    }

    public void CloseComputer()
    {
        // Запускаем анимацию закрытия компьютера
        CloseComp.SetTrigger("field_out");
    }

    // Метод, который будет вызван событием анимации при открытии компьютера
    public void ActivateComputerUI()
    {
        // Включаем интерфейс компьютера и кнопку выхода
        ComputerCanvas.SetActive(true);
    }

    // Метод, который будет вызван событием анимации при закрытии компьютера
    public void DeactivateComputerUI()
    {
        // Выключаем интерфейс компьютера и кнопку выхода
        ComputerCanvas.SetActive(false);
    }
}

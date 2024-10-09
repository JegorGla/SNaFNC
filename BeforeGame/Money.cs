using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText; // UI текст для отображения суммы денег
    public int amount = 10; // Сумма, которая будет добавлена при нажатии клавиши
    private int currentMoney = 0; // Текущая сумма денег

    void Start()
    {
        UpdateMoneyText(); // Обновляем текст с начальным значением
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(amount);
        }
    }

    // Метод для добавления денег
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        currentMoney = Mathf.Clamp(currentMoney, 0, 99999); // Ограничиваем значение
        UpdateMoneyText();
    }

    // Метод для проверки и траты денег
    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyText();
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }

    // Метод для обновления текста
    private void UpdateMoneyText()
    {
        moneyText.text = currentMoney.ToString();
    }

    // Метод для получения текущего баланса
    public int GetMoney()
    {
        return currentMoney;
    }
}

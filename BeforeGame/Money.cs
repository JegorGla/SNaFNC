using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText; // UI ����� ��� ����������� ����� �����
    public int amount = 10; // �����, ������� ����� ��������� ��� ������� �������
    private int currentMoney = 0; // ������� ����� �����

    void Start()
    {
        UpdateMoneyText(); // ��������� ����� � ��������� ���������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(amount);
        }
    }

    // ����� ��� ���������� �����
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        currentMoney = Mathf.Clamp(currentMoney, 0, 99999); // ������������ ��������
        UpdateMoneyText();
    }

    // ����� ��� �������� � ����� �����
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

    // ����� ��� ���������� ������
    private void UpdateMoneyText()
    {
        moneyText.text = currentMoney.ToString();
    }

    // ����� ��� ��������� �������� �������
    public int GetMoney()
    {
        return currentMoney;
    }
}

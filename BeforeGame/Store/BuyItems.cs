using UnityEngine;

public class BuyItems : MonoBehaviour
{
    public Money moneyScript; // ������ �� ������, ����������� ��������
    public int energeticPrice = 15; // ���� ����������
    public int censoredPackPrice = 50; // ���� ���������������� ������
    public int AmongusCost = 100;

    public GameObject YouAlreadyHaveItem; // ���������, ��� � ��� ��� ���� �������
    public GameObject YouHaveNotItem; // ���������, ��� � ��� ��� �������� (�� �������)

    public GameObject YouHaveItem; // ���������, ��� ������� ������
    public GameObject YouHavenotItem; // ���������, ��� ������� �� ������

    public AudioSource bought; // ���� ��� �������

    public bool energeticBought = false; // ����, ��� ��������� ��� ������
    public bool packBought = false; // ����, ��� ��������������� ����� ��� ������
    public bool amongus = false;

    void Start()
    {
        YouAlreadyHaveItem.SetActive(false);
        YouHaveItem.SetActive(false);

        YouHavenotItem.SetActive(true);
        YouHaveNotItem.SetActive(true);

        // �������� ��������� �������
        packBought = PlayerPrefs.GetInt("PackBought", 0) == 1;
        amongus = PlayerPrefs.GetInt("AmonBought", 0) == 1;
        energeticBought = PlayerPrefs.GetInt("EnergeticBought", 0) == 1;

        UpdateUI(); // ��������� UI � ����������� �� ��������� �������
    }


    // ����� ��� ������� ����������
    public void BuyEnergetic()
    {
        if (energeticBought)
        {
            UpdateUI();
            return; // ��������� ��� ������, �� ����� ��������� ������� �����
        }

        if (moneyScript.SpendMoney(energeticPrice))
        {
            bought.Play();
            energeticBought = true;

            // ��������� ���������� � ������� ����������
            PlayerPrefs.SetInt("EnergeticBought", 1);
            PlayerPrefs.Save();

            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough money to buy energetic!");
            UpdateUI();
        }
    }

    // ����� ��� ������� ���������������� ������
    public void BuyPackCensored()
    {
        if (packBought)
        {
            Debug.LogWarning("Pack already bought!");
            UpdateUI();
            return; // ����� ��� ������, �� ����� ��������� ������� �����
        }

        if (moneyScript.SpendMoney(censoredPackPrice))
        {
            Debug.Log("Censored Pack bought!");
            bought.Play();
            packBought = true;

            // ��������� ���������� � ������� ������
            PlayerPrefs.SetInt("PackBought", 1);
            PlayerPrefs.Save();

            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough money to buy censored pack!");
            UpdateUI();
        }
    }

    public void BuyAmongus()
    {
        if (amongus) // ���� ��� �������
        {
            UpdateUI();
            return; // ������� �� ������
        }

        if (moneyScript.SpendMoney(AmongusCost))
        {
            bought.Play();
            amongus = true;

            // ��������� ���������� � �������
            PlayerPrefs.SetInt("AmonBought", 1);
            PlayerPrefs.Save();

            UpdateUI();
        }
        else
        {
            UpdateUI();
        }
    }



    // ����� ��� ���������� UI � ����������� �� �������� ��������� �������
    private void UpdateUI()
    {
        YouAlreadyHaveItem.SetActive(energeticBought && packBought && amongus);
        YouHaveItem.SetActive(energeticBought || packBought || amongus);

        YouHavenotItem.SetActive(!energeticBought || !packBought || !amongus);
        YouHaveNotItem.SetActive(!energeticBought || !packBought || !amongus);
    }
}

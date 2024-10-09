using UnityEngine;

public class BuyItems : MonoBehaviour
{
    public Money moneyScript; // Ссылка на скрипт, управляющий деньгами
    public int energeticPrice = 15; // Цена энергетика
    public int censoredPackPrice = 50; // Цена цензурированного пакета
    public int AmongusCost = 100;

    public GameObject YouAlreadyHaveItem; // Сообщение, что у вас уже есть предмет
    public GameObject YouHaveNotItem; // Сообщение, что у вас нет предмета (до покупки)

    public GameObject YouHaveItem; // Сообщение, что предмет куплен
    public GameObject YouHavenotItem; // Сообщение, что предмет не куплен

    public AudioSource bought; // Звук при покупке

    public bool energeticBought = false; // Флаг, что энергетик был куплен
    public bool packBought = false; // Флаг, что цензурированный пакет был куплен
    public bool amongus = false;

    void Start()
    {
        YouAlreadyHaveItem.SetActive(false);
        YouHaveItem.SetActive(false);

        YouHavenotItem.SetActive(true);
        YouHaveNotItem.SetActive(true);

        // Проверка состояния покупок
        packBought = PlayerPrefs.GetInt("PackBought", 0) == 1;
        amongus = PlayerPrefs.GetInt("AmonBought", 0) == 1;
        energeticBought = PlayerPrefs.GetInt("EnergeticBought", 0) == 1;

        UpdateUI(); // Обновляем UI в зависимости от состояния покупок
    }


    // Метод для покупки энергетика
    public void BuyEnergetic()
    {
        if (energeticBought)
        {
            UpdateUI();
            return; // Энергетик уже куплен, не нужно выполнять покупку снова
        }

        if (moneyScript.SpendMoney(energeticPrice))
        {
            bought.Play();
            energeticBought = true;

            // Сохраняем информацию о покупке энергетика
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

    // Метод для покупки цензурированного пакета
    public void BuyPackCensored()
    {
        if (packBought)
        {
            Debug.LogWarning("Pack already bought!");
            UpdateUI();
            return; // Пакет уже куплен, не нужно выполнять покупку снова
        }

        if (moneyScript.SpendMoney(censoredPackPrice))
        {
            Debug.Log("Censored Pack bought!");
            bought.Play();
            packBought = true;

            // Сохраняем информацию о покупке пакета
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
        if (amongus) // Если уже куплено
        {
            UpdateUI();
            return; // Выходим из метода
        }

        if (moneyScript.SpendMoney(AmongusCost))
        {
            bought.Play();
            amongus = true;

            // Сохраняем информацию о покупке
            PlayerPrefs.SetInt("AmonBought", 1);
            PlayerPrefs.Save();

            UpdateUI();
        }
        else
        {
            UpdateUI();
        }
    }



    // Метод для обновления UI в зависимости от текущего состояния покупок
    private void UpdateUI()
    {
        YouAlreadyHaveItem.SetActive(energeticBought && packBought && amongus);
        YouHaveItem.SetActive(energeticBought || packBought || amongus);

        YouHavenotItem.SetActive(!energeticBought || !packBought || !amongus);
        YouHaveNotItem.SetActive(!energeticBought || !packBought || !amongus);
    }
}

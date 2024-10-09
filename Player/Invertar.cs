using UnityEngine;
using UnityEngine.UI;

public class Invertar : MonoBehaviour
{
    public Image[] takeditem; // Массив ячеек для предметов

    public void AddItemToInventory(Sprite itemSprite)
    {
        // Проходимся по массиву ячеек инвентаря
        for (int i = 0; i < takeditem.Length; i++)
        {
            // Проверяем, если текущая ячейка пустая
            if (takeditem[i].sprite == null)
            {
                // Устанавливаем изображение предмета в первую пустую ячейку
                takeditem[i].sprite = itemSprite;
                takeditem[i].gameObject.SetActive(true);
                return; // Выходим из метода после добавления
            }
        }

        Debug.Log("Инвентарь полон!"); // Сообщение, если инвентарь полон
    }
}

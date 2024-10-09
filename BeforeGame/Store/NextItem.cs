using UnityEngine;
using UnityEngine.UI;

public class NextItem : MonoBehaviour
{
    public GameObject[] items;
    public Text[] text;
    public GameObject[] Buttons;

    private int currentIndexItem = 0;
    private int currentIndexText = 0;
    private int currentIndexButton = 0;

    private void Start()
    {
        if (items.Length > 0 && text.Length > 0 && Buttons.Length > 0)
        {
            // ���������� ������ �������, ������ ����� � ������ ������
            items[0].SetActive(true);
            text[0].gameObject.SetActive(true);
            Buttons[0].SetActive(true);

            // ������������ ��� ��������� ��������, ������ � ������
            for (int i = 1; i < items.Length; i++)
            {
                items[i].SetActive(false);
            }

            for (int i = 1; i < text.Length; i++)
            {
                text[i].gameObject.SetActive(false);
            }

            for (int i = 1; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(false);
            }
        }
    }

    public void nextItem()
    {
        if (items.Length == 0 || text.Length == 0 || Buttons.Length == 0)
        {
            return;
        }

        // ������������ ������� �������, ����� � ������
        items[currentIndexItem].SetActive(false);
        text[currentIndexText].gameObject.SetActive(false);
        Buttons[currentIndexButton].SetActive(false);

        // ��������� � ���������� ��������, ������ � ������
        currentIndexItem = (currentIndexItem + 1) % items.Length;
        currentIndexText = (currentIndexText + 1) % text.Length;
        currentIndexButton = (currentIndexButton + 1) % Buttons.Length;

        // ���������� ��������� �������, ����� � ������
        items[currentIndexItem].SetActive(true);
        text[currentIndexText].gameObject.SetActive(true);
        Buttons[currentIndexButton].SetActive(true);
    }
}

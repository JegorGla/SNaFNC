using UnityEngine;
using UnityEngine.UI;

public class Invertar : MonoBehaviour
{
    public Image[] takeditem; // ������ ����� ��� ���������

    public void AddItemToInventory(Sprite itemSprite)
    {
        // ���������� �� ������� ����� ���������
        for (int i = 0; i < takeditem.Length; i++)
        {
            // ���������, ���� ������� ������ ������
            if (takeditem[i].sprite == null)
            {
                // ������������� ����������� �������� � ������ ������ ������
                takeditem[i].sprite = itemSprite;
                takeditem[i].gameObject.SetActive(true);
                return; // ������� �� ������ ����� ����������
            }
        }

        Debug.Log("��������� �����!"); // ���������, ���� ��������� �����
    }
}

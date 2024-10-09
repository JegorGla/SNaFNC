using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeVino : MonoBehaviour
{
    public float distance = 3f; // ���������, �� ������� ����� ����� ����������������� � ��������
    public Sprite sprite; // ������ ��� ���������
    public Invertar invertar; // ������ �� ������ ���������
    public Text text; // ���� ������ ��� ����������� ���������� ���������
    private int Vinofloat = 0; // ������� ���������� ��������� � ���������
    private const int maxVino = 7; // ������������ ���������� ��������� � ���������

    private void Start()
    {
        DeactivateImage();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance) && hit.transform.CompareTag("Vino"))
            {
                CollectVino(hit.transform.gameObject);
            }
        }
    }

    public void CollectVino(GameObject vino)
    {
        if (Vinofloat < maxVino)
        {
            if (invertar != null && sprite != null)
            {
                int itemIndex = invertar.GetItemIndex(sprite);
                if (itemIndex != -1)
                {
                    UpdateItemCount(itemIndex); // ����������� ���������� ��������
                }
                else
                {
                    invertar.AddItemToInventory(sprite); // ��������� ����� ������� � ���������
                    Vinofloat++;
                    text.text = Vinofloat.ToString(); // ������������� ����������
                    ActivateImage(); // ���������� ����������� ��� �����������
                }
            }

            vino.SetActive(false);
        }
        else
        {
            Debug.Log("��������� �����!");
        }
    }

    private void UpdateItemCount(int itemIndex)
    {
        Vinofloat++; // ����������� ���������� � ���������
        text.text = Vinofloat.ToString(); // ��������� �����
    }

    private void ActivateImage()
    {
        // ��� ��� ��� ��������� �����������
    }

    private void DeactivateImage()
    {
        // ��� ��� ��� ����������� �����������
    }
}

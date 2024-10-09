using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // ���������, �� ������� ����� ����� ����������������� � ��������
    public Invertar invertar; // ������ �� ������ ���������

    public void Update()
    {
        // ���������, ������ �� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������ � ����������� ����
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ���������, ����� �� ��� � ������
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Vino"))
                {
                    // �������� ������
                    GameObject vino = hit.transform.gameObject;
                    // �������� ������ �� ���������� SpriteRenderer
                    Sprite vinoSprite = vino.GetComponent<SpriteRenderer>().sprite;
                    vino.SetActive(false); // ������������ ������ ����� ����� �����

                    // ��������� � ���������
                    invertar.AddItemToInventory(vinoSprite); // ��������� ������ � ���������
                }

                if (hit.transform.CompareTag("Button"))
                {
                    // �������� ������
                    GameObject cleaner = hit.transform.gameObject;
                    // �������� ������ �� ���������� SpriteRenderer
                    Sprite cleanerSprite = cleaner.GetComponent<SpriteRenderer>().sprite;
                    cleaner.SetActive(false); // ������������ ������ ����� ����� �����

                    // ��������� � ���������
                    invertar.AddItemToInventory(cleanerSprite); // ��������� ������ � ���������
                }
            }
        }
    }
}

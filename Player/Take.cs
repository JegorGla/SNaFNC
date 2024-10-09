using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // ���������, �� ������� ����� ����� ����������������� � ��������
    public Invertar invertar; // ������ �� ������ ���������

    public Image[] ImageForTake; // ������ ����������� ��� ���������

    private void Start()
    {
        DeactivateAllImages(); // ������������ ��� ����������� ��� ������
    }

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

                    ActivateImage(vinoSprite); // ���������� �����������
                }

                if (hit.transform.CompareTag("Cleaner")) // �������� "Button" �� "Cleaner"
                {
                    // �������� ������
                    GameObject cleaner = hit.transform.gameObject;
                    // �������� ������ �� ���������� SpriteRenderer
                    Sprite cleanerSprite = cleaner.GetComponent<SpriteRenderer>().sprite;
                    cleaner.SetActive(false); // ������������ ������ ����� ����� �����

                    // ��������� � ���������
                    invertar.AddItemToInventory(cleanerSprite); // ��������� ������ � ���������

                    ActivateImage(cleanerSprite); // ���������� �����������
                }
            }
        }
    }

    public void ActivateImage(Sprite itemSprite)
    {
        // ���������� ����������� ��� ���������������� ��������
        for (int i = 0; i < ImageForTake.Length; i++)
        {
            if (ImageForTake[i].sprite == itemSprite)
            {
                ImageForTake[i].gameObject.SetActive(true);
                break; // ��������� ���� ����� ���������
            }
        }
    }

    public void DeactivateAllImages()
    {
        // ������������ ��� ����������� � �������
        for (int i = 0; i < ImageForTake.Length; i++)
        {
            ImageForTake[i].gameObject.SetActive(false);
        }
    }
}

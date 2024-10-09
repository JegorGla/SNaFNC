using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public float distance = 3f; // ���������, �� ������� ����� ����� ����������������� � ��������
    public Image[] ImageForTake; // ������ ����������� ��� ����������� ��� ������� ��������
    public Sprite[] sprites; // ������ �������� ��� ���������
    public Invertar invertar; // ������ �� ������ ���������

    private void Start()
    {
        // ������������ ��� ����������� � ������� ImageForTake
        DeactivateImages();
    }

    public void Update()
    {
        // ���������, ������ �� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ������� ��� �� ������ � ����������� ����
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ���������, ����� �� ��� � ������ � ������ "Vino" ��� "Butt"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Vino"))
                {
                    TakeVino();
                }
                else if (hit.transform.CompareTag("Button"))
                {
                    TakeButt();
                }
            }
        }
    }

    private void TakeVino()
    {
        ActivateImages();
        if (invertar != null && sprites.Length > 0)
        {
            invertar.AddItemToInventory(sprites[0]); // ��������� ������ ������ �� �������
        }
    }

    private void TakeButt()
    {
        ActivateImages();
        if (invertar != null && sprites.Length > 1)
        {
            invertar.AddItemToInventory(sprites[1]); // ��������� ������ ������ �� �������
        }
    }

    private void ActivateImages()
    {
        // ���������� ��� ����������� � ������� ImageForTake
        if (ImageForTake != null)
        {
            foreach (var image in ImageForTake)
            {
                if (image != null)
                {
                    image.gameObject.SetActive(true);
                }
            }
        }
    }

    private void DeactivateImages()
    {
        // ������������ ��� ����������� � ������� ImageForTake
        if (ImageForTake != null)
        {
            foreach (var image in ImageForTake)
            {
                if (image != null)
                {
                    image.gameObject.SetActive(false);
                }
            }
        }
    }
}

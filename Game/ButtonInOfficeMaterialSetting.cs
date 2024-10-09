using System.Collections;
using UnityEngine;

public class ButtonInOfficeMaterialSetting : MonoBehaviour
{
    public Material closedButtonMaterial; // �������� ��� �������� ������
    public Material openedButtonMaterial; // �������� ��� �������� ������

    public Renderer Button1;
    public Renderer Button2;

    private float interactionDistance = 3f;

    // ��������� ������
    private bool isButton1Open = false;
    private bool isButton2Open = false;

    void Start()
    {
        // ������������� ����������� �������� ��� ������
        Button1.material = closedButtonMaterial;
        Button2.material = closedButtonMaterial;
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // ���������, ���� �� � ������� ��������� � ����� ������ ��� �����
            if (hit.collider != null)
            {
                // ���������, �� ����� ������ ������
                if (hit.transform == Button1.transform)
                {
                    // ����������� ��������� ������ 1
                    isButton1Open = !isButton1Open;
                    Button1.material = isButton1Open ? openedButtonMaterial : closedButtonMaterial;

                    // ��������� ������ 2, ���� ��� ���� �������
                    if (isButton2Open)
                    {
                        isButton2Open = false;
                        Button2.material = closedButtonMaterial;
                    }
                }
                else if (hit.transform == Button2.transform)
                {
                    // ����������� ��������� ������ 2
                    isButton2Open = !isButton2Open;
                    Button2.material = isButton2Open ? openedButtonMaterial : closedButtonMaterial;

                    // ��������� ������ 1, ���� ��� ���� �������
                    if (isButton1Open)
                    {
                        isButton1Open = false;
                        Button1.material = closedButtonMaterial;
                    }
                }
            }
        }
    }
}

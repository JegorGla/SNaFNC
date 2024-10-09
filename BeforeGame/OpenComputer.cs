using Unity.VisualScripting;
using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject ComputerCanvas;

    public Animator OpenComp; // �������� ��� �������� ����������
    public Animator CloseComp; // �������� ��� �������� ����������

    private void Start()
    {
        // ��������� ���������: ��������� ����������, ������ ������ � ���������� ���������
        ComputerCanvas.SetActive(false);

        // �������� ������ �� ���������, ������������� � ����� �������
        OpenComp = GetComponent<Animator>();
        CloseComp = GetComponent<Animator>();

    }

    public void openComputer()
    {
        // ��������� �������� �������� ����������
        OpenComp.SetTrigger("Field_screen");
    }

    public void CloseComputer()
    {
        // ��������� �������� �������� ����������
        CloseComp.SetTrigger("field_out");
    }

    // �����, ������� ����� ������ �������� �������� ��� �������� ����������
    public void ActivateComputerUI()
    {
        // �������� ��������� ���������� � ������ ������
        ComputerCanvas.SetActive(true);
    }

    // �����, ������� ����� ������ �������� �������� ��� �������� ����������
    public void DeactivateComputerUI()
    {
        // ��������� ��������� ���������� � ������ ������
        ComputerCanvas.SetActive(false);
    }
}

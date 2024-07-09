using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject ComputerCanvas;

    public Animator OpenComp; // �������� ��� �������� ����������
    public Animator CloseComp; // �������� ��� �������� ����������
    public Animator Player;

    private void Start()
    {
        // ��������� ���������: ��������� ����������, ������ ������ � ���������� ���������
        ComputerCanvas.SetActive(false);

        // �������� ������ �� ���������, ������������� � ����� �������
        OpenComp = GetComponent<Animator>();
        CloseComp = GetComponent<Animator>();
        Player = GetComponent<Animator>();
    }

    public void openComputer()
    {
        // ��������� �������� �������� ����������
        OpenComp.SetTrigger("Field_screen");
        Player.SetTrigger("Go");
    }

    public void CloseComputer()
    {
        // ��������� �������� �������� ����������
        CloseComp.SetTrigger("field_out");
        Player.SetTrigger("Exit");
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

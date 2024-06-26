using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SettingCamera;
    public GameObject BackFromGame;

    private bool isSetting = false;

    private void Start()
    {
        // ���������� ��������� ������
        CloseSetting();
    }

    // ����� ��� ������������ ��������� ��������
    public void ToggleSetting()
    {
        isSetting = !isSetting;

        if (isSetting)
        {
            OpenSetting();
        }
        else
        {
            CloseSetting();
        }
    }

    // ����� ��� �������� ��������
    public void OpenSetting()
    {
        Panel.SetActive(false);
        SettingCamera.SetActive(true);
        BackFromGame.SetActive(true);
    }

    // ����� ��� �������� ��������
    public void CloseSetting()
    {
        Panel.SetActive(true);
        SettingCamera.SetActive(false);
        BackFromGame.SetActive(false);
    }
}

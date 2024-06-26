using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SettingCamera;
    public GameObject BackFromGame;

    private bool isSetting = false;

    private void Start()
    {
        // Изначально настройки скрыты
        CloseSetting();
    }

    // Метод для переключения состояния настроек
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

    // Метод для открытия настроек
    public void OpenSetting()
    {
        Panel.SetActive(false);
        SettingCamera.SetActive(true);
        BackFromGame.SetActive(true);
    }

    // Метод для закрытия настроек
    public void CloseSetting()
    {
        Panel.SetActive(true);
        SettingCamera.SetActive(false);
        BackFromGame.SetActive(false);
    }
}

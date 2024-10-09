using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject setting;
    public GameObject Exit;
    public GameObject Play;
    public GameObject Info;

    public GameObject EmtpySetting;
    

    //private bool isSetting = false;    // Flag to track if settings are currently open

    // Method to open the settings
    public void OpenSetting()
    {
        setting.SetActive(false);
        Exit.SetActive(false);
        Play.SetActive(false);
        Info.SetActive(false);

        EmtpySetting.SetActive(true);
    }

    // Method to close the settings
    public void CloseSetting()
    {
        setting.SetActive(true);
        Exit.SetActive(true);
        Play.SetActive(true);
        Info.SetActive(true);

        EmtpySetting.SetActive(false);
    }
}

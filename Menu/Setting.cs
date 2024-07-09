using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject BackFromGame;    // Reference to the back button
    public GameObject setting;
    public GameObject Exit;
    public GameObject Play;
    public GameObject volume;
    public GameObject sensivity;
    public GameObject SaveSetting;
    public GameObject Ukranian;
    public GameObject Polish;
    public GameObject English;
    

    private bool isSetting = false;    // Flag to track if settings are currently open

    // Method to open the settings
    void OpenSetting()
    {
        BackFromGame.SetActive(true);  // Show the back button
        setting.SetActive(false);
        Exit.SetActive(false);
        Play.SetActive(false);
        volume.SetActive(true);
        SaveSetting.SetActive(true);
       
        Ukranian.SetActive(true);
        Polish.SetActive(true);
        English.SetActive(true);
        sensivity.SetActive(true);
    }

    // Method to close the settings
    void CloseSetting()
    {
        BackFromGame.SetActive(false); // Hide the back button
        setting.SetActive(true);
        Exit.SetActive(true);
        Play.SetActive(true);
        volume.SetActive(false);
        SaveSetting.SetActive(false);
        sensivity.SetActive(false);

        Ukranian.SetActive(false);
        Polish.SetActive(false);
        English.SetActive(false);
    }
}

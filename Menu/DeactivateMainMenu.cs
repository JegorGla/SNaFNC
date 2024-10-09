using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMainMenu : MonoBehaviour
{
    public GameObject Play;
    public GameObject Setting;
    public GameObject Exit;
    public GameObject Info;

    public void DeactivateMenu()
    {
        Play.SetActive(false);
        Setting.SetActive(false);
        Exit.SetActive(false);
        Info.SetActive(false);
    }

    public void ActivateMainMenu()
    {
        Play.SetActive(true);
        Setting.SetActive(true);
        Exit.SetActive(true);
        Info.SetActive(true);
    }
}

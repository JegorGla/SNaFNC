using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpdateInfo : MonoBehaviour
{
    public GameObject info;
    public GameObject PanelInfo;
    public GameObject CloseInfo;

    public GameObject Play;
    public GameObject Setting;
    public GameObject Exit;

    void Start()
    {
        info.SetActive(true);
        PanelInfo.SetActive(false);
        CloseInfo.SetActive(false);
    }

    public void OpenInfo()
    {
        Play.SetActive(false);
        Setting.SetActive(false);
        Exit.SetActive(false);

        info.SetActive(false);
        PanelInfo.SetActive(true);
        CloseInfo.SetActive(true);
    }

    public void closeInfo()
    {
        Play.SetActive(true);
        Setting.SetActive(true);
        Exit.SetActive(true);

        info.SetActive(true);
        PanelInfo.SetActive(false);
        CloseInfo.SetActive(false);
    }
}

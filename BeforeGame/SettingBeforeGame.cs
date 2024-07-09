using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBeforeGame : MonoBehaviour
{
    public GameObject PlayerGoToComp;
    public GameObject PlayerInOffice;

    void Start()
    {
        PlayerGoToComp.SetActive(false);
        PlayerInOffice.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activatePlayer()
    {
        PlayerGoToComp.SetActive(true);
        PlayerInOffice.SetActive(false);
    }
}

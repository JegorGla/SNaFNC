using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenModes : MonoBehaviour
{
    public GameObject Modes;

    void Start()
    {
        Modes.SetActive(false);
    }

    // Update is called once per frame
    public void OpenMode()
    {
        Modes.SetActive(true);
    }
}

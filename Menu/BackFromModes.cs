using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromModes : MonoBehaviour
{
    public GameObject Modes;
    
    public void CloseMode()
    {
        Modes.SetActive(false);
    }
}

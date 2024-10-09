using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCamera : MonoBehaviour
{
    public AudioSource CLICKC;

    public void OPenCamera()
    {
        if (CLICKC != null)
        {
            CLICKC.Play();
        }
    }
}

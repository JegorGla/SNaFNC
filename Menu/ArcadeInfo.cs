using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeInfo : MonoBehaviour
{
    public GameObject CanvasInfoArcade;

    void Start()
    {
        CanvasInfoArcade.SetActive(false);
    }

    public void SeeInfo()
    {
        CanvasInfoArcade.SetActive(true);
    }

    public void GotIt()
    {
        CanvasInfoArcade.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCamera : MonoBehaviour
{
    public Canvas MisionCanvas;

    public GameObject ExitCamera;

    public GameObject CameraRigthWall;
    public GameObject CameraForFredda;
    public GameObject CameraLeftWall;
    public GameObject CameraInOffice;

    public GameObject CameraMap;

    public GameObject FreddaCanvas;

    public GameObject HandIcon;
    public GameObject StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        CameraRigthWall.SetActive(false);
        CameraForFredda.SetActive(false);
        CameraLeftWall.SetActive(false);
        CameraInOffice.SetActive(false);
        StaminaBar.SetActive(false);
        HandIcon.SetActive(false);
        ExitCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraRigthWall.activeSelf)
        {
            ExitCamera.SetActive(true);
        }
        else if (CameraForFredda.activeSelf)
        {
            ExitCamera.SetActive(true);
        }
        else if (CameraLeftWall.activeSelf)
        {
            ExitCamera.SetActive(true);
        }
        else if(CameraInOffice.activeSelf)
        {
            ExitCamera.SetActive(true);
        }
    }

    public void ExitCam()
    {
        if (ExitCamera.activeSelf)
        {
            MisionCanvas.gameObject.SetActive(true);

            HandIcon.SetActive(true);
            StaminaBar.SetActive(true);

            CameraMap.SetActive(false);
            ExitCamera.SetActive(false);
            CameraRigthWall.SetActive(false);
            CameraLeftWall.SetActive(false);
            CameraForFredda.SetActive(false);
            CameraInOffice.SetActive(false);
            FreddaCanvas.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCamera : MonoBehaviour
{
    public GameObject ExitCamera;
    public GameObject Camera;

    public GameObject HandIcon;
    public GameObject StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        Camera.SetActive(false);
        StaminaBar.SetActive(false);
        HandIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.activeSelf)
        {
            ExitCamera.SetActive(true);
        }
    }

    public void ExitCam()
    {
        if (ExitCamera.activeSelf)
        {
            HandIcon.SetActive(true);
            StaminaBar.SetActive(true);
            ExitCamera.SetActive(false);
            Camera.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

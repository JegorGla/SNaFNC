using UnityEngine;

public class OpenCamera : MonoBehaviour
{
    public Canvas MisionCanvas;

    public GameObject PC;
    public GameObject MainCamera;

    public GameObject CameraRightWall;
    public GameObject FreddaCamera;
    public GameObject CameraInOffice;
    public GameObject CameraLeftWall;
    public GameObject Zal;

    public GameObject Nakrutka;

    private GameObject lastOpenedCamera;

    public GameObject HandIcon;
    public GameObject StaminaBar;

    public GameObject CameraMap;

    public Walk player;

    public float distance = 3f;

    void Start()
    {
        CameraRightWall.SetActive(false);
        FreddaCamera.SetActive(false);
        CameraInOffice.SetActive(false);
        CameraLeftWall.SetActive(false);

        Nakrutka.SetActive(false);

        StaminaBar.SetActive(true);
        HandIcon.SetActive(true);

        player = GetComponent<Walk>();

        lastOpenedCamera = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == PC)
            {
                OpenPC();
                HandIcon.SetActive(false);
            }
        }
    }

    void OpenPC()
    {
        if (Vector3.Distance(player.transform.position, PC.transform.position) <= distance)
        {   
            MisionCanvas.gameObject.SetActive(false);
            CameraMap.SetActive(true);
            if (lastOpenedCamera != null)
            {
                lastOpenedCamera.SetActive(true);
                if (lastOpenedCamera == FreddaCamera)
                {
                    Nakrutka.SetActive(true);
                }
            }

            else
            {
                CameraRightWall.SetActive(true);
                lastOpenedCamera = CameraRightWall;
            }

            HandIcon.SetActive(false);
            StaminaBar.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void OpenFreddasCamera()
    {
        if (lastOpenedCamera != null)
        {
            lastOpenedCamera.SetActive(false);
        }

        FreddaCamera.SetActive(true);
        Nakrutka.SetActive(true);
        lastOpenedCamera = FreddaCamera;
    }

    public void OpenRightWall()
    {
        if (lastOpenedCamera != null)
        {
            lastOpenedCamera.SetActive(false);
        }

        CameraRightWall.SetActive(true);
        lastOpenedCamera = CameraRightWall;
    }

    public void OpenLeftWall()
    {
        if (lastOpenedCamera != null)
        {
            lastOpenedCamera.SetActive(false);
        }

        CameraLeftWall.SetActive(true);
        lastOpenedCamera = CameraLeftWall;
    }

    public void OpenOffice()
    {
        if (lastOpenedCamera != null)
        {
            lastOpenedCamera.SetActive(false);
        }

        CameraInOffice.SetActive(true);
        lastOpenedCamera = CameraInOffice;
    }
    public void OpenZal()
    {
        if (lastOpenedCamera != null)
        {
            lastOpenedCamera.SetActive(false);
        }

        Zal.SetActive(true);
        lastOpenedCamera = Zal;
    }
}

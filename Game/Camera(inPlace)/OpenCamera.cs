using UnityEngine;

public class OpenCamera : MonoBehaviour
{
    public GameObject PC;
    public GameObject MainCamera;
    public GameObject CameraRightWall;
    

    public GameObject HandIcon;
    public GameObject StaminaBar;

    public Walk player;

    public float distance = 3f;

    void Start()
    {
        CameraRightWall.SetActive(false);
        StaminaBar.SetActive(true);
        HandIcon.SetActive(true);
        player = GetComponent<Walk>();
    }
    
    void Update()
    {
        // Проверяем, нажата ли кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из центра камеры в мировом пространстве
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, сталкивается ли луч с каким-либо объектом
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == PC)
            {
                Open();
                HandIcon.SetActive(false);
            }
        }
    }

    void Open()
    {
        // Проверяем расстояние между игроком и компьютером
        if (Vector3.Distance(player.transform.position, PC.transform.position) <= distance)
        {
            // Открываем камеру на стене
            CameraRightWall.SetActive(true);
            HandIcon.SetActive(false);
            StaminaBar.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devyat_chy_Desiat : MonoBehaviour
{
    public GameObject old_phone;
    public Camera Camera;
    public AudioSource Mem;

    private bool isCall;

    private void Start()
    {
        Mem = GetComponent<AudioSource>();
        isCall = false;
    }

    private void Update()
    {
        // Проверяем, нажата ли кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из камеры в точку на экране, на которую указывает мышь
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, сталкивается ли луч с каким-либо объектом
            if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, сталкивается ли луч с old_phone и имеет ли объект правильный тег
                if (hit.transform.CompareTag("Old_Phone"))
                {
                    if (!isCall)
                    {
                        Mem.Play();
                        isCall = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Mem.Stop();
                    }
                }
            }
        }
    }
}

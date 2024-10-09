using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject PlayerHand;
    public GameObject CameraRightWall;
    private float Distance = 3f;

    private void Start()
    {
        PlayerHand.SetActive(false);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Проверяем пересечение луча с объектами в указанном диапазоне
        if (Physics.Raycast(ray, out hit, Distance))
        {
            // Проверяем, имеет ли объект нужный тег или активна ли CameraRightWall
            if (hit.transform.CompareTag("Vino") || hit.transform.CompareTag("Button") || hit.transform.CompareTag("Computer") || hit.transform.CompareTag("Old_Phone") || hit.transform.CompareTag("DoorInWood") || hit.transform.CompareTag("Amongus") || hit.transform.CompareTag("Bathroom_toilet_door") || hit.transform.CompareTag("Toilet"))
            {
                PlayerHand.SetActive(true);
            }
            else
            {
                PlayerHand.SetActive(false);
            }
        }
        else
        {
            PlayerHand.SetActive(false);
        }

        // Дополнительная проверка на состояние CameraRightWall
        if (CameraRightWall.activeSelf)
        {
            PlayerHand.SetActive(false);
        }
    }
}

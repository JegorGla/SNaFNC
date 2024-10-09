using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMONGUUUUUS : MonoBehaviour
{
    private readonly float distance = 3f; // Сделали поле readonly
    public AudioSource Amng;

    void Start()
    {
        Amng = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, distance) && hit.transform.CompareTag("Amongus"))
            {
                Amng.Play();
            }
        }
    }
}

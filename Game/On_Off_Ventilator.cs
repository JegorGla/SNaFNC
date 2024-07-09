using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class On_Off_Ventilator : MonoBehaviour
{

    public GameObject Ventilator;

    float distance = 3f;

    public AudioSource shum_ventulatora;

    void Start()
    {
        shum_ventulatora = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.tag == "Ventilator")
            {
                shum_ventulatora.Play();
            }
            else
            {
                shum_ventulatora.Stop();
            }
        }
    }
}

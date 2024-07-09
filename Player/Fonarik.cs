using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonarik : MonoBehaviour
{
    public Light FL;
    public AudioSource OnOffLight;
    

    void Start()
    {
        FL.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(FL.enabled == false)
            {
                OnOffLight.Play();
                FL.enabled = true;
            }
            else
            {
                OnOffLight.Play();
                FL.enabled = false;
            }
        }
    }
}

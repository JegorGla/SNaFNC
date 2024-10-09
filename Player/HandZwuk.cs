using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandZwuk : MonoBehaviour
{
    public GameObject Hand;
    public AudioSource hand;

    private bool isPlaying = false;

    void Start()
    {
        if (hand == null)
        {
            hand = GetComponent<AudioSource>();
            if (hand == null)
            {
                Debug.LogError("AudioSource component not found on the GameObject.");
            }
        }
    }

    void Update()
    {
        if (Hand.activeSelf && !isPlaying)
        {
            hand.Play();
            isPlaying = true;
        }
        else if (!Hand.activeSelf && isPlaying)
        {
            hand.Stop();
            isPlaying = false;
        }
    }
}

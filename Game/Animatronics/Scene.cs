using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public Transform player;
    public Transform fredda;

    public AudioSource Screamer;

    public FreddaAi iiFredda;

    // Update is called once per frame
    void Update()
    {
        if (player == fredda)
        {
            iiFredda.RUN.Stop();
            Screamer.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenZanawieshki : MonoBehaviour
{
    public Animator Zanawieska1;
    public Animator Zanawieska2;

    public LookingFredda NakrutkaScript; // —сылка на скрипт LookingFredda

    void Start()
    {
        if (Zanawieska1 == null || Zanawieska2 == null)
        {
            Debug.LogError("Animators are not set in the Inspector");
        }
        if (NakrutkaScript == null)
        {
            Debug.LogError("LookingFredda script is not set in the Inspector");
        }
    }

    void Update()
    {
        if (NakrutkaScript != null)
        {
            float currentNakrutka = NakrutkaScript.currentNakrutka; // »спользуем свойство

            if (currentNakrutka <= 0f)
            {
                if (Zanawieska1 != null)
                {
                    Zanawieska1.SetTrigger("Open");
                }
                if (Zanawieska2 != null)
                {
                    Zanawieska2.SetTrigger("Open");
                }
            }
        }
    }
}

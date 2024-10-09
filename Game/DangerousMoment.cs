using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousMoment : MonoBehaviour
{
    public GameObject DM;

    void Start()
    {
        DM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            DM.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        DM.SetActive(false);
    }
}

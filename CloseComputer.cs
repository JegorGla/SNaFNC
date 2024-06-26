using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseComputer : MonoBehaviour
{
    public GameObject ComputerCanvas;

    private Animator _anim;

    private bool isClose;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        ComputerCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        isClose = !isClose;
        if (isClose)
        {
            _anim.SetTrigger("TrgClose");
            ComputerCanvas.SetActive(false);
        }
    }
}

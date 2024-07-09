using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseLaptop : MonoBehaviour
{
    private Animator mAnimator;
    private bool IsOpenLapTop;
    public GameObject Nout;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        Nout = GetComponent<GameObject>();
        Nout.SetActive(false);
    }

    private void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {

                if (!IsOpenLapTop)
                {
                    Nout.SetActive(true);
                    mAnimator.SetTrigger("TrOpen");
                    IsOpenLapTop = true;
                }
                else
                {
                    Nout.SetActive(false);
                    mAnimator.SetTrigger("TrClose");
                    IsOpenLapTop = false;
                }
            }
        }
    }
}
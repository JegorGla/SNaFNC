using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInOffice : MonoBehaviour
{
    public GameObject PlayerInOfficeStay;
    public GameObject GoTOpc;
    public GameObject ReturnFromPc;

    public Animator Player;

    void Start()
    {
        // Инициализируем аниматоры для каждого объекта
        Player = PlayerInOfficeStay.GetComponent<Animator>();
    }

    public void GOToPc()
    {
        Player.SetTrigger("Go");
    }
    public void Return()
    {
        Player.SetTrigger("Return");
    }
}

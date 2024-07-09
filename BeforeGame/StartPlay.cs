using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    public GameObject StartGame;

    // Start is called before the first frame update
    void Start()
    {
        StartGame.SetActive(true);
    }

    // �����, ������� ����� ��������� � ������ Start
    public void StartPlayGame()
    {
        SceneManager.LoadScene("ArcadeMode");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    public float nightDuration = 600f; // ����������������� ���� � �������� (10 �����)
    private float timer;
    private bool gameWon;

    public AudioSource NCEcho;
    public Text timerText; // UI ������� ��� ����������� �������

    public AudioSource WinGameMus;
    public AudioSource StartNight;

    void Start()
    {
        timer = nightDuration;
        gameWon = false;
        NCEcho.loop = true; // ������������� ������������ ������
        StartNight.Play();  
    }

    void Update()
    {
        if (timer >= 5)
        {
            NCEcho.Play();
        }


        if (!gameWon)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();
            if (timer <= 0)
            {
                WinGame();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void WinGame()
    {
        gameWon = true;
        timerText.text = "You Survived the Night!";
        // ����� ����� �������� �������������� ��������, ������� ���������� ��� ������
        WinGameMus.Play();
    }
}

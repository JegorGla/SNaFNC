using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    public float nightDuration = 600f; // ѕродолжительность ночи в секундах (10 минут)
    private float timer;
    private bool gameWon;

    public AudioSource NCEcho;
    public Text timerText; // UI элемент дл€ отображени€ времени

    public AudioSource WinGameMus;
    public AudioSource StartNight;

    void Start()
    {
        timer = nightDuration;
        gameWon = false;
        NCEcho.loop = true; // ”станавливаем зацикливание музыки
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
        // «десь можно добавить дополнительные действи€, которые происход€т при победе
        WinGameMus.Play();
    }
}

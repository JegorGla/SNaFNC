using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    public float nightDuration = 600f; // ѕродолжительность ночи в секундах (10 минут)
    private float timer;
    private bool gameWon;

    public AudioSource NCEcho;
    public Text timerText; // UI элемент дл€ отображени€ времени

    void Start()
    {
        timer = nightDuration;
        gameWon = false;
        NCEcho.loop = true; // ”станавливаем зацикливание музыки
        NCEcho.Play();
    }

    void Update()
    {
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
    }
}

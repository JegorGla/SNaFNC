using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused;

    public GameObject exitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        exitButton.SetActive(true); // Показываем кнопку выхода
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void ResumeGame()
    {
        pausePanel.SetActive(false);
        exitButton.SetActive(false); // Прячем кнопку выхода
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ClosePause()
    {
        isPaused = false;
        ResumeGame();
    }

    public void ExitFromGame()
    {
        Time.timeScale = 1.0f; // Возвращаем нормальный ход времени перед выходом
        SceneManager.LoadScene("Menu");
    }
}

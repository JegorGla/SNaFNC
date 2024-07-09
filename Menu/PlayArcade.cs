using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayArcade : MonoBehaviour
{
    public GameObject playButton;
    public GameObject panel;
    private bool isMenu = true;

    private void Start()
    {
        panel.SetActive(true);
        playButton.SetActive(true);
    }

    public void LoadArcadeMode()
    {
        if (isMenu)
        {
            // Загружаємо сцену "ArcadeMode"
            SceneManager.LoadScene("BeforeGame");
            // Встановлюємо флаг меню в false
            isMenu = false;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayArcade : MonoBehaviour
{
    public GameObject playButton;
    public GameObject panel;

    //private bool isMenu = true;

    public GameObject CanvasMenu;
    public GameObject progressBar;

    public GameObject LoaderCanvas;

    public AudioSource mainMusic;

    private void Start()
    {
        panel.SetActive(true);
        playButton.SetActive(true);
    }

    public void LoadArcadeMode()
    {
        CanvasMenu.SetActive(false);
        progressBar.SetActive(true);
        LoaderCanvas.SetActive(true);
        mainMusic.Stop();
    }
}
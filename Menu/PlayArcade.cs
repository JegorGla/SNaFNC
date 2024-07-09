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
            // ��������� ����� "ArcadeMode"
            SceneManager.LoadScene("BeforeGame");
            // ������������ ���� ���� � false
            isMenu = false;
        }
    }
}
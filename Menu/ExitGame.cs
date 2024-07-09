using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject ExitButt;

    void Start()
    {
        if (ExitButt != null)
        {
            ExitButt.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Exit button is not assigned in the inspector.");
        }
    }

    public void Quit()
    {
        // ≈сли мы в редакторе Unity, то остановим игру
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ≈сли мы в построенном приложении, то закроем его
            Application.Quit();
#endif
    }
}

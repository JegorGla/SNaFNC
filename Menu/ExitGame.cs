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
        // ���� �� � ��������� Unity, �� ��������� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ���� �� � ����������� ����������, �� ������� ���
            Application.Quit();
#endif
    }
}

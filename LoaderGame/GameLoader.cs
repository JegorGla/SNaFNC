using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public Slider progressBar;
    public GameObject CanvasLoader;

    public AudioSource MusicLoader;

    public void Start()
    {
        progressBar.gameObject.SetActive(false);
    }

    public void LoadingBeforeArcade()
    {
        CanvasLoader.gameObject.SetActive(true);
        // �������� �������� �����
        StartCoroutine(LoadSceneAsync("BeforeGame")); // ������� ��� ����� ����� �����
        MusicLoader.Play();
    }
    public void LoadingArcade()
    {
        CanvasLoader.gameObject.SetActive(true);
        // �������� �������� �����
        StartCoroutine(LoadSceneAsync("ArcadeMode")); // ������� ��� ����� ����� �����
        MusicLoader.Play();
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // ��������� ����������� �������� �������� �����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // ��������� �������� �������� (�������� ��������� ���� �� 0 �� 0.9)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressBar.value = progress;

            // ���������, ��������� �� ��������
            if (asyncOperation.progress >= 0.9f)
            {
                // ��� ����������� ������� �������� ����� ���������� �����
                yield return new WaitForSeconds(2.2f);
                asyncOperation.allowSceneActivation = true;
            }

            // �������� ���������� �����
            yield return null;
        }
    }
}

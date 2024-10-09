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
        // Начинаем загрузку сцены
        StartCoroutine(LoadSceneAsync("BeforeGame")); // Укажите имя вашей сцены здесь
        MusicLoader.Play();
    }
    public void LoadingArcade()
    {
        CanvasLoader.gameObject.SetActive(true);
        // Начинаем загрузку сцены
        StartCoroutine(LoadSceneAsync("ArcadeMode")); // Укажите имя вашей сцены здесь
        MusicLoader.Play();
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Запускаем асинхронную операцию загрузки сцены
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // Вычисляем прогресс загрузки (значение прогресса идет от 0 до 0.9)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressBar.value = progress;

            // Проверяем, завершена ли загрузка
            if (asyncOperation.progress >= 0.9f)
            {
                // Для визуального эффекта задержки перед активацией сцены
                yield return new WaitForSeconds(2.2f);
                asyncOperation.allowSceneActivation = true;
            }

            // Ожидание следующего кадра
            yield return null;
        }
    }
}

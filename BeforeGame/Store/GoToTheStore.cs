using System.Collections;
using UnityEngine;

public class GoToTheStore : MonoBehaviour
{
    public CanvasGroup panel; // Панель, которую нужно плавно показать и скрыть
    public Camera storeCamera; // Камера магазина
    public Camera mainCamera; // Основная камера

    public float fadeDuration = 1f; // Длительность изменения прозрачности
    public float displayDuration = 1f; // Время, в течение которого панель будет видна

    void Start()
    {
        if (panel != null)
        {
            panel.alpha = 0f;
        }

        if (storeCamera != null)
        {
            storeCamera.gameObject.SetActive(false);
        }
    }

    public void GoToStore()
    {
        StartCoroutine(ShowPanelAndSwitchCamera());
    }

    public void ReturnFromStore()
    {
        StartCoroutine(ShowPanelAndReturnCamera());
    }

    private IEnumerator ShowPanelAndSwitchCamera()
    {
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(displayDuration);

        storeCamera.gameObject.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(panel, 1f, 0f, fadeDuration));

        mainCamera.gameObject.SetActive(false);
    }



    private IEnumerator ShowPanelAndReturnCamera()
    {
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(displayDuration);

        mainCamera.gameObject.SetActive(true);
        storeCamera.gameObject.SetActive(false);

        // Скрываем панель сразу
        panel.alpha = 0f;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }
        cg.alpha = end;
    }
}

using System.Collections;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject Buttons;

    public Canvas StoreCanv; // Canvas магазина
    public CanvasGroup fadePanel; // Панель для плавного перехода

    public Camera StoreCamera;
    public Camera OfficeCamera;

    public float fadeDuration = 1f; // Длительность изменения прозрачности
    public float displayDuration = 1f; // Время, в течение которого панель будет видна
    public float uiDelay = 1f; // Задержка перед активацией Canvas

    void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.alpha = 0f;
        }

        if (StoreCamera != null)
        {
            StoreCamera.gameObject.SetActive(false);
        }

        if (StoreCanv != null)
        {
            StoreCanv.gameObject.SetActive(false);
        }
    }

    public void GoToTheStore()
    {
        Buttons.SetActive(false);

        StartCoroutine(ShowPanelAndSwitchCamera());
    }

    public void ReturnFromStore()
    {
        StoreCanv.gameObject.SetActive(false);
        StartCoroutine(ShowPanelAndReturnCamera());
    }

    private IEnumerator ShowPanelAndSwitchCamera()
    {
        yield return StartCoroutine(FadeCanvasGroup(fadePanel, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(displayDuration);

        StoreCamera.gameObject.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(fadePanel, 1f, 0f, fadeDuration));

        OfficeCamera.gameObject.SetActive(false);

        StartCoroutine(ActivateUIWithDelay());
    }

    private IEnumerator ShowPanelAndReturnCamera()
    {
        yield return StartCoroutine(FadeCanvasGroup(fadePanel, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(displayDuration);

        OfficeCamera.gameObject.SetActive(true);
        StoreCamera.gameObject.SetActive(false);

        fadePanel.alpha = 0f;

        Buttons.SetActive(true);
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

    private IEnumerator ActivateUIWithDelay()
    {
        yield return new WaitForSeconds(uiDelay);
        StoreCanv.gameObject.SetActive(true);
    }
}

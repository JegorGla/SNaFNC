using System.Collections;
using UnityEngine;

public class aVAIBLEfUTURE : MonoBehaviour
{
    public GameObject CanvasFuture; // Меню, которое нужно открыть

    private float fadeDuration = 0.2f; // Длительность анимации

    private CanvasGroup canvasGroup;

    void Start()
    {
        // Получаем или добавляем CanvasGroup к CanvasFuture
        canvasGroup = CanvasFuture.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = CanvasFuture.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f; // Изначально невидимо
        CanvasFuture.SetActive(false); // Изначально выключено
    }

    public void OpenAvaible()
    {
        CanvasFuture.SetActive(true); // Включаем меню
        StartCoroutine(FadeInMenu());
    }

    public void CLoseAvaible()
    {
        StartCoroutine(FadeOutMenu());
    }

    private IEnumerator FadeInMenu()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration); // Плавное появление
            yield return null;
        }
        canvasGroup.alpha = 1f; // Убедимся, что альфа выставлена на 1
    }

    private IEnumerator FadeOutMenu()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration); // Плавное исчезновение
            yield return null;
        }
        canvasGroup.alpha = 0f; // Убедимся, что альфа выставлена на 0
        CanvasFuture.SetActive(false); // Отключаем меню после исчезновения
    }
}

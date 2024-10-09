using System.Collections;
using UnityEngine;

public class fieldKeyBoardTips : MonoBehaviour
{
    public GameObject[] images; // Массив изображений

    public float displayDuration = 5f; // Время показа изображений
    public float fadeDuration = 1f; // Длительность перехода (появления и исчезновения)

    private CanvasGroup[] imageCanvasGroups;

    void Start()
    {
        // Получаем или добавляем CanvasGroup для каждого изображения
        imageCanvasGroups = new CanvasGroup[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            imageCanvasGroups[i] = images[i].GetComponent<CanvasGroup>();
            if (imageCanvasGroups[i] == null)
            {
                imageCanvasGroups[i] = images[i].AddComponent<CanvasGroup>();
            }
            imageCanvasGroups[i].alpha = 0f; // Устанавливаем начальную прозрачность в 0 (скрыто)
        }

        // Запускаем последовательность показа и скрытия изображений
        StartCoroutine(ShowAndHideAllImages());
    }

    private IEnumerator ShowAndHideAllImages()
    {
        // Плавно показываем все изображения
        foreach (CanvasGroup cg in imageCanvasGroups)
        {
            StartCoroutine(FadeIn(cg));
        }

        // Ждем, пока изображения будут показаны на экране
        yield return new WaitForSeconds(displayDuration);

        // Плавно скрываем все изображения
        foreach (CanvasGroup cg in imageCanvasGroups)
        {
            StartCoroutine(FadeOut(cg));
        }
    }

    private IEnumerator FadeIn(CanvasGroup cg)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
        cg.alpha = 1f; // Убедимся, что альфа выставлена на 1
    }

    private IEnumerator FadeOut(CanvasGroup cg)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }
        cg.alpha = 0f; // Убедимся, что альфа выставлена на 0
    }
}

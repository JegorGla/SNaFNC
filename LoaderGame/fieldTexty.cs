using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fieldTexty : MonoBehaviour
{
    public Text[] tipsTexts; // Массив текстов с советами
    public GameObject[] images; // Массив изображений

    public float displayDuration = 5f; // Время показа каждого совета и изображения
    public float fadeDuration = 1f; // Длительность перехода между советами и изображениями

    private CanvasGroup[] textCanvasGroups;
    private CanvasGroup[] imageCanvasGroups;
    private int currentTipIndex = 0;

    void Start()
    {
        // Получаем CanvasGroup для каждого текста
        textCanvasGroups = new CanvasGroup[tipsTexts.Length];
        for (int i = 0; i < tipsTexts.Length; i++)
        {
            textCanvasGroups[i] = tipsTexts[i].GetComponent<CanvasGroup>();
            if (textCanvasGroups[i] == null)
            {
                textCanvasGroups[i] = tipsTexts[i].gameObject.AddComponent<CanvasGroup>();
            }
            textCanvasGroups[i].alpha = (i == 0) ? 1 : 0; // Только первый текст виден
        }

        // Получаем CanvasGroup для каждого изображения
        imageCanvasGroups = new CanvasGroup[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            imageCanvasGroups[i] = images[i].GetComponent<CanvasGroup>();
            if (imageCanvasGroups[i] == null)
            {
                imageCanvasGroups[i] = images[i].AddComponent<CanvasGroup>();
            }
            imageCanvasGroups[i].alpha = (i == 0) ? 1 : 0; // Только первое изображение видно
        }

        // Запускаем цикл смены советов и изображений
        StartCoroutine(CycleTipsAndImages());
    }

    private IEnumerator CycleTipsAndImages()
    {
        while (true) // Бесконечный цикл смены советов и изображений
        {
            // Ждем, пока совет и изображение будут показаны на экране
            yield return new WaitForSeconds(displayDuration);

            // Плавно скрываем текущий совет и изображение
            StartCoroutine(FadeOut(textCanvasGroups[currentTipIndex]));
            StartCoroutine(FadeOut(imageCanvasGroups[currentTipIndex]));

            // Переходим к следующему совету и изображению
            currentTipIndex = (currentTipIndex + 1) % tipsTexts.Length;

            // Плавно показываем следующий совет и изображение
            StartCoroutine(FadeIn(textCanvasGroups[currentTipIndex]));
            StartCoroutine(FadeIn(imageCanvasGroups[currentTipIndex]));
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

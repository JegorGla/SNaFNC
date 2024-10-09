using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fieldTexty : MonoBehaviour
{
    public Text[] tipsTexts; // ������ ������� � ��������
    public GameObject[] images; // ������ �����������

    public float displayDuration = 5f; // ����� ������ ������� ������ � �����������
    public float fadeDuration = 1f; // ������������ �������� ����� �������� � �������������

    private CanvasGroup[] textCanvasGroups;
    private CanvasGroup[] imageCanvasGroups;
    private int currentTipIndex = 0;

    void Start()
    {
        // �������� CanvasGroup ��� ������� ������
        textCanvasGroups = new CanvasGroup[tipsTexts.Length];
        for (int i = 0; i < tipsTexts.Length; i++)
        {
            textCanvasGroups[i] = tipsTexts[i].GetComponent<CanvasGroup>();
            if (textCanvasGroups[i] == null)
            {
                textCanvasGroups[i] = tipsTexts[i].gameObject.AddComponent<CanvasGroup>();
            }
            textCanvasGroups[i].alpha = (i == 0) ? 1 : 0; // ������ ������ ����� �����
        }

        // �������� CanvasGroup ��� ������� �����������
        imageCanvasGroups = new CanvasGroup[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            imageCanvasGroups[i] = images[i].GetComponent<CanvasGroup>();
            if (imageCanvasGroups[i] == null)
            {
                imageCanvasGroups[i] = images[i].AddComponent<CanvasGroup>();
            }
            imageCanvasGroups[i].alpha = (i == 0) ? 1 : 0; // ������ ������ ����������� �����
        }

        // ��������� ���� ����� ������� � �����������
        StartCoroutine(CycleTipsAndImages());
    }

    private IEnumerator CycleTipsAndImages()
    {
        while (true) // ����������� ���� ����� ������� � �����������
        {
            // ����, ���� ����� � ����������� ����� �������� �� ������
            yield return new WaitForSeconds(displayDuration);

            // ������ �������� ������� ����� � �����������
            StartCoroutine(FadeOut(textCanvasGroups[currentTipIndex]));
            StartCoroutine(FadeOut(imageCanvasGroups[currentTipIndex]));

            // ��������� � ���������� ������ � �����������
            currentTipIndex = (currentTipIndex + 1) % tipsTexts.Length;

            // ������ ���������� ��������� ����� � �����������
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
        cg.alpha = 1f; // ��������, ��� ����� ���������� �� 1
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
        cg.alpha = 0f; // ��������, ��� ����� ���������� �� 0
    }
}

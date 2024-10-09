using System.Collections;
using UnityEngine;

public class fieldKeyBoardTips : MonoBehaviour
{
    public GameObject[] images; // ������ �����������

    public float displayDuration = 5f; // ����� ������ �����������
    public float fadeDuration = 1f; // ������������ �������� (��������� � ������������)

    private CanvasGroup[] imageCanvasGroups;

    void Start()
    {
        // �������� ��� ��������� CanvasGroup ��� ������� �����������
        imageCanvasGroups = new CanvasGroup[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            imageCanvasGroups[i] = images[i].GetComponent<CanvasGroup>();
            if (imageCanvasGroups[i] == null)
            {
                imageCanvasGroups[i] = images[i].AddComponent<CanvasGroup>();
            }
            imageCanvasGroups[i].alpha = 0f; // ������������� ��������� ������������ � 0 (������)
        }

        // ��������� ������������������ ������ � ������� �����������
        StartCoroutine(ShowAndHideAllImages());
    }

    private IEnumerator ShowAndHideAllImages()
    {
        // ������ ���������� ��� �����������
        foreach (CanvasGroup cg in imageCanvasGroups)
        {
            StartCoroutine(FadeIn(cg));
        }

        // ����, ���� ����������� ����� �������� �� ������
        yield return new WaitForSeconds(displayDuration);

        // ������ �������� ��� �����������
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

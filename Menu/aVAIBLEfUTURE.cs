using System.Collections;
using UnityEngine;

public class aVAIBLEfUTURE : MonoBehaviour
{
    public GameObject CanvasFuture; // ����, ������� ����� �������

    private float fadeDuration = 0.2f; // ������������ ��������

    private CanvasGroup canvasGroup;

    void Start()
    {
        // �������� ��� ��������� CanvasGroup � CanvasFuture
        canvasGroup = CanvasFuture.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = CanvasFuture.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f; // ���������� ��������
        CanvasFuture.SetActive(false); // ���������� ���������
    }

    public void OpenAvaible()
    {
        CanvasFuture.SetActive(true); // �������� ����
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
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration); // ������� ���������
            yield return null;
        }
        canvasGroup.alpha = 1f; // ��������, ��� ����� ���������� �� 1
    }

    private IEnumerator FadeOutMenu()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration); // ������� ������������
            yield return null;
        }
        canvasGroup.alpha = 0f; // ��������, ��� ����� ���������� �� 0
        CanvasFuture.SetActive(false); // ��������� ���� ����� ������������
    }
}

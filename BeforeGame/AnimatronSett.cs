using System.Collections;
using UnityEngine;

public class AnimatronSett : MonoBehaviour
{
    public CanvasGroup panel; // ������, ������� ����� ������ �������� � ������
    public Canvas AnimatronSet; // Canvas ��� ������������� ��������
    public Camera AnimatronSetting; // ������ ��� ������������� ��������
    public Camera MainCamera; // �������� ������

    public GameObject StoreG;
    public GameObject PlayerSett;
    public GameObject GoToWork;
    public GameObject Computer;
    public GameObject AnimatronicsSett;

    public GameObject Back;
    public GameObject FredaButton;

    public float fadeDuration = 1f; // ������������ ��������� ������������
    public float displayDuration = 1f; // �����, � ������� �������� ������ ����� �����

    void Start()
    {
        if (panel != null)
        {
            panel.alpha = 0f;
            panel.gameObject.SetActive(true); // ���������, ��� ������ �������, ����� ������ ����
        }

        AnimatronSet.gameObject.SetActive(false);
        AnimatronSetting.gameObject.SetActive(false); // ���������� ������ ������������� �������� ���������
    }

    // ����� ��� �������� � ������������ ���������
    public void GoToTheAnimatronics()
    {
        StoreG.SetActive(false);
        PlayerSett.SetActive(false);
        GoToWork.SetActive(false);
        Computer.SetActive(false);
        AnimatronicsSett.SetActive(false);
        StartCoroutine(ShowPanelAndSwitchCameraAnimat());
    }

    // ����� ��� �������� �� ������������ ��������
    public void ReturnFromTheAnimatronics()
    {
        Back.SetActive(false);
        FredaButton.SetActive(false);
        StartCoroutine(HidePanelAndSwitchCameraBack());
    }

    private IEnumerator ShowPanelAndSwitchCameraAnimat()
    {
        // ������� ����������� ������
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));

        // ������ ������ ������� � ������� ���������� �������
        yield return new WaitForSeconds(displayDuration);

        // ��������� �������� ������ � �������� ������ ������������� ��������
        if (MainCamera != null)
        {
            MainCamera.gameObject.SetActive(false);
        }

        if (AnimatronSetting != null)
        {
            AnimatronSetting.gameObject.SetActive(true);
        }

        // ���������� Canvas ������������� ��������
        AnimatronSet.gameObject.SetActive(true);

        // ������� ������� ������
        yield return StartCoroutine(FadeCanvasGroup(panel, 1f, 0f, fadeDuration));
    }

    private IEnumerator HidePanelAndSwitchCameraBack()
    {
        // ������� ����������� ������
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));

        // ������ ������ ������� � ������� ���������� �������
        yield return new WaitForSeconds(displayDuration);

        // �������� Canvas ������������� ��������
        if (AnimatronSet != null)
        {
            AnimatronSet.gameObject.SetActive(false);
        }

        // ��������� ������ ������������� �������� � �������� �������� ������
        if (AnimatronSetting != null)
        {
            AnimatronSetting.gameObject.SetActive(false);
        }

        if (MainCamera != null)
        {
            MainCamera.gameObject.SetActive(true);
        }

        // �������� ��� ����� ����������� ��������
        StoreG.SetActive(true);
        PlayerSett.SetActive(true);
        GoToWork.SetActive(true);
        Computer.SetActive(true);
        AnimatronicsSett.SetActive(true);

        // ������� ������� ������
        yield return StartCoroutine(FadeCanvasGroup(panel, 1f, 0f, fadeDuration));
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

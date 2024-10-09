using System.Collections;
using UnityEngine;

public class AnimatronSett : MonoBehaviour
{
    public CanvasGroup panel; // Панель, которую нужно плавно показать и скрыть
    public Canvas AnimatronSet; // Canvas для анимационного настроек
    public Camera AnimatronSetting; // Камера для анимационного настроек
    public Camera MainCamera; // Основная камера

    public GameObject StoreG;
    public GameObject PlayerSett;
    public GameObject GoToWork;
    public GameObject Computer;
    public GameObject AnimatronicsSett;

    public GameObject Back;
    public GameObject FredaButton;

    public float fadeDuration = 1f; // Длительность изменения прозрачности
    public float displayDuration = 1f; // Время, в течение которого панель будет видна

    void Start()
    {
        if (panel != null)
        {
            panel.alpha = 0f;
            panel.gameObject.SetActive(true); // Убедитесь, что панель активна, чтобы начать фейд
        }

        AnimatronSet.gameObject.SetActive(false);
        AnimatronSetting.gameObject.SetActive(false); // Изначально камера анимационного настроек отключена
    }

    // Метод для перехода в анимационные настройки
    public void GoToTheAnimatronics()
    {
        StoreG.SetActive(false);
        PlayerSett.SetActive(false);
        GoToWork.SetActive(false);
        Computer.SetActive(false);
        AnimatronicsSett.SetActive(false);
        StartCoroutine(ShowPanelAndSwitchCameraAnimat());
    }

    // Метод для возврата из анимационных настроек
    public void ReturnFromTheAnimatronics()
    {
        Back.SetActive(false);
        FredaButton.SetActive(false);
        StartCoroutine(HidePanelAndSwitchCameraBack());
    }

    private IEnumerator ShowPanelAndSwitchCameraAnimat()
    {
        // Плавное отображение панели
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));

        // Держим панель видимой в течение указанного времени
        yield return new WaitForSeconds(displayDuration);

        // Отключаем основную камеру и включаем камеру анимационного настроек
        if (MainCamera != null)
        {
            MainCamera.gameObject.SetActive(false);
        }

        if (AnimatronSetting != null)
        {
            AnimatronSetting.gameObject.SetActive(true);
        }

        // Отображаем Canvas анимационного настроек
        AnimatronSet.gameObject.SetActive(true);

        // Плавное скрытие панели
        yield return StartCoroutine(FadeCanvasGroup(panel, 1f, 0f, fadeDuration));
    }

    private IEnumerator HidePanelAndSwitchCameraBack()
    {
        // Плавное отображение панели
        yield return StartCoroutine(FadeCanvasGroup(panel, 0f, 1f, fadeDuration));

        // Держим панель видимой в течение указанного времени
        yield return new WaitForSeconds(displayDuration);

        // Скрываем Canvas анимационного настроек
        if (AnimatronSet != null)
        {
            AnimatronSet.gameObject.SetActive(false);
        }

        // Отключаем камеру анимационного настроек и включаем основную камеру
        if (AnimatronSetting != null)
        {
            AnimatronSetting.gameObject.SetActive(false);
        }

        if (MainCamera != null)
        {
            MainCamera.gameObject.SetActive(true);
        }

        // Включаем все ранее отключенные элементы
        StoreG.SetActive(true);
        PlayerSett.SetActive(true);
        GoToWork.SetActive(true);
        Computer.SetActive(true);
        AnimatronicsSett.SetActive(true);

        // Плавное скрытие панели
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

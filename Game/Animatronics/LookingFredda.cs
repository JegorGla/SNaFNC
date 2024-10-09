using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LookingFredda : MonoBehaviour
{
    public UnityEvent onNakrutkaZero; // Событие для нулевой накрутки

    public float currentNakrutka;
    private float nakruchywat;
    public float propadanije_nakrutki;

    public Image Nakrutka;

    public GameObject Danger;
    public GameObject CameraForFredda;
    public GameObject Nakruchka;

    public AudioSource Smeh;
    public AudioSource Nakrut;
    public AudioSource Beep;
    private bool dangerActivated;
    public Animator Fredda;

    private Color nakrutkaColor; // Переменная для хранения цвета Nakrutka

    void Start()
    {
        currentNakrutka = 75f;
        nakruchywat = 15f;
        propadanije_nakrutki = 1f;

        Danger.SetActive(false);
        dangerActivated = false;

        // Сохраняем исходный цвет Nakrutka
        if (Nakrutka != null)
        {
            nakrutkaColor = Nakrutka.color;
        }
    }

    void Update()
    {
        UpdateNakrutka();
        CheckBeep();
        HandleCameraVisibility();
        HandleDanger();
    }

    private void UpdateNakrutka()
    {
        currentNakrutka -= propadanije_nakrutki * Time.deltaTime;
        currentNakrutka = Mathf.Clamp(currentNakrutka, 0f, 100f);

        if (Nakrutka != null)
        {
            Nakrutka.fillAmount = currentNakrutka / 100f;
        }
    }

    private void CheckBeep()
    {
        if (currentNakrutka <= 15f && Beep != null && !Beep.isPlaying)
        {
            Beep.Play();
        }
    }

    private void HandleCameraVisibility()
    {
        if (CameraForFredda.activeSelf)
        {
            Nakruchka.SetActive(true);
            SetNakrutkaVisibility(1f);
        }
        else
        {
            Nakruchka.SetActive(false);
            SetNakrutkaVisibility(0f);
        }
    }

    private void HandleDanger()
    {
        if (currentNakrutka <= 0f && !dangerActivated)
        {
            Smeh?.Play();

            if (CameraForFredda.activeSelf)
            {
                Danger.SetActive(true);
                dangerActivated = true;
            }
            else
            {
                Danger.SetActive(false);
            }

            onNakrutkaZero?.Invoke(); // Вызов события, когда накрутка достигает нуля

            Beep?.Stop();
            Fredda.SetTrigger("IGoForYou");
        }
    }

    public void IncreaseNakrutka()
    {
        currentNakrutka += nakruchywat;
        currentNakrutka = Mathf.Clamp(currentNakrutka, 0f, 100f);
        PlayNakrutSound();
    }

    private void PlayNakrutSound()
    {
        Nakrut?.Play();
    }

    private void SetNakrutkaVisibility(float alpha)
    {
        if (Nakrutka != null)
        {
            nakrutkaColor.a = alpha;
            Nakrutka.color = nakrutkaColor;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;
    private float volume = 1f;

    void Start()
    {
        // Проверка на существование сохраненного значения громкости в PlayerPrefs
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            volume = PlayerPrefs.GetFloat("VolumeLevel");
        }
        else
        {
            volume = 1f; // Значение громкости по умолчанию
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;

        // Настройка слайдера
        volumeSlider.value = volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("VolumeLevel", volume);
    }
}

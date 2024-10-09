using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer audioMixer; // Ссылка на ваш AudioMixer
    public Slider volumeSlider;

    void Start()
    {
        // Проверка на существование сохраненного значения громкости в PlayerPrefs
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            float volume = PlayerPrefs.GetFloat("VolumeLevel");
            volumeSlider.value = volume;
            SetVolume(volume);
        }
        else
        {
            volumeSlider.value = 1f; // Значение громкости по умолчанию
        }

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Убедитесь, что имя параметра совпадает с тем, что в AudioMixer
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeLevel", volume);
    }
}

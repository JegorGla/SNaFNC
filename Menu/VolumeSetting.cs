using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer audioMixer; // ������ �� ��� AudioMixer
    public Slider volumeSlider;

    void Start()
    {
        // �������� �� ������������� ������������ �������� ��������� � PlayerPrefs
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            float volume = PlayerPrefs.GetFloat("VolumeLevel");
            volumeSlider.value = volume;
            SetVolume(volume);
        }
        else
        {
            volumeSlider.value = 1f; // �������� ��������� �� ���������
        }

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // ���������, ��� ��� ��������� ��������� � ���, ��� � AudioMixer
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeLevel", volume);
    }
}

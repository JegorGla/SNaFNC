using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivitySettings : MonoBehaviour
{
    public Slider sensitivitySlider;

    void Start()
    {
        float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        sensitivitySlider.value = sensitivity;
        sensitivitySlider.onValueChanged.AddListener(delegate { OnSensitivityChanged(); });
    }

    public void OnSensitivityChanged()
    {
        float sensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }
}

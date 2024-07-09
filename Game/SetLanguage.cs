using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLanguage : MonoBehaviour
{
    public int language;

    void Start()
    {
        language = PlayerPrefs.GetInt("language", 0);
        Debug.Log("Current Language: " + language);
    }

    public void EnglishLang()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("Menu");
    }
    public void UkrainianLang()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("Menu");
    }
    public void PolishLang()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("Menu");
    }
}

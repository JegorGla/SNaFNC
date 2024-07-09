using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    public int language;
    public string[] texts; // Массив строк для разных языков
    private Text textline;

    // Start is called before the first frame update
    void Start()
    {
        // Загрузка языка
        language = PlayerPrefs.GetInt("language", 0);
        textline = GetComponent<Text>();

        // Проверка, был ли найден компонент Text
        if (textline == null)
        {
            Debug.LogError("Text component not found on " + gameObject.name);
            return;
        }

        // Проверка на допустимый индекс
        if (texts == null || texts.Length == 0)
        {
            Debug.LogError("Texts array is not assigned or empty on " + gameObject.name);
            return;
        }

        if (language >= 0 && language < texts.Length)
        {
            textline.text = texts[language];
        }
        else
        {
            Debug.LogError("Language index out of range");
        }
    }
}

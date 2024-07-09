using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    public int language;
    public string[] texts; // ������ ����� ��� ������ ������
    private Text textline;

    // Start is called before the first frame update
    void Start()
    {
        // �������� �����
        language = PlayerPrefs.GetInt("language", 0);
        textline = GetComponent<Text>();

        // ��������, ��� �� ������ ��������� Text
        if (textline == null)
        {
            Debug.LogError("Text component not found on " + gameObject.name);
            return;
        }

        // �������� �� ���������� ������
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

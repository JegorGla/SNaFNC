using UnityEngine;

public class BackFromSetting : MonoBehaviour
{
    public GameObject backFromSetting;
    private bool isBack;

    public GameObject Setting;
    public GameObject PlayArcade;
    public GameObject ExitFromGame;

    // Start is called before the first frame update
    void Start()
    {
        backFromSetting.SetActive(false);
    }

    // Метод для переключения состояния настроек
    public void ToggleBack()
    {
        isBack = !isBack;

        if (isBack)
        {
            backFromSetting.SetActive(true);
        }
        else
        {
            Active();
        }
    }

    public void Active()
    {
        backFromSetting.SetActive(false);

        ExitFromGame.SetActive(true);
        PlayArcade.SetActive(true);
        Setting.SetActive(true);
    }
}

using UnityEngine;

public class ClickClickInMenu : MonoBehaviour
{
    public AudioSource click; // Убедитесь, что это ссылка на AudioSource для звуков кнопок

    // Метод, вызываемый при нажатии на кнопку
    public void Click()
    {
        if (click != null)
        {
            click.Play();
        }
    }
}

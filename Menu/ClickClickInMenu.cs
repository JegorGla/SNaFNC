using UnityEngine;

public class ClickClickInMenu : MonoBehaviour
{
    public AudioSource click; // ���������, ��� ��� ������ �� AudioSource ��� ������ ������

    // �����, ���������� ��� ������� �� ������
    public void Click()
    {
        if (click != null)
        {
            click.Play();
        }
    }
}

using System.Collections;
using UnityEngine;

public class OpenCloseLaptop : MonoBehaviour
{
    public Animator LapTOp; // �������� �������� ����� ���������
    public GameObject Nout; // ������ �������� �������� ����� ���������

    private bool IsOpenLapTop;

    void Start()
    {
        if (Nout != null)
        {
            SetLaptopVisible(false); // ���������� ������� �� �����
        }
    }

    void Update()
    {
        if (LapTOp != null && Nout != null)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!IsOpenLapTop)
                {
                    SetLaptopVisible(true);
                    LapTOp.SetTrigger("Open");
                    IsOpenLapTop = true;
                }
                else
                {
                    LapTOp.SetTrigger("Close");
                    IsOpenLapTop = false;
                    // ���������� �������� ��� �������� ��������� ��������
                    StartCoroutine(DeactivateNoutAfterAnimation());
                }
            }
        }
    }

    private IEnumerator DeactivateNoutAfterAnimation()
    {
        // ���� ��������� �������� ��������
        yield return new WaitForSeconds(LapTOp.GetCurrentAnimatorStateInfo(0).length);
        SetLaptopVisible(false);
    }

    private void SetLaptopVisible(bool visible)
    {
        // ���������/�������� ��������� ���� MeshRenderer'�� ������ ��������
        MeshRenderer[] renderers = Nout.GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = visible;
        }

        // ���� ���� Canvas, �������� ��� UI-���������, ��������� �� �����������
        Canvas[] canvases = Nout.GetComponentsInChildren<Canvas>();
        foreach (var canvas in canvases)
        {
            canvas.enabled = visible;
        }
    }
}

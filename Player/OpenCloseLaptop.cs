using System.Collections;
using UnityEngine;

public class OpenCloseLaptop : MonoBehaviour
{
    public Animator LapTOp; // Аниматор назначен через инспектор
    public GameObject Nout; // Объект ноутбука назначен через инспектор

    private bool IsOpenLapTop;

    void Start()
    {
        if (Nout != null)
        {
            SetLaptopVisible(false); // Изначально ноутбук не видим
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
                    // Используем корутину для ожидания окончания анимации
                    StartCoroutine(DeactivateNoutAfterAnimation());
                }
            }
        }
    }

    private IEnumerator DeactivateNoutAfterAnimation()
    {
        // Ждем окончания анимации закрытия
        yield return new WaitForSeconds(LapTOp.GetCurrentAnimatorStateInfo(0).length);
        SetLaptopVisible(false);
    }

    private void SetLaptopVisible(bool visible)
    {
        // Отключаем/включаем рендеринг всех MeshRenderer'ов внутри ноутбука
        MeshRenderer[] renderers = Nout.GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = visible;
        }

        // Если есть Canvas, например для UI-элементов, отключаем их отображение
        Canvas[] canvases = Nout.GetComponentsInChildren<Canvas>();
        foreach (var canvas in canvases)
        {
            canvas.enabled = visible;
        }
    }
}

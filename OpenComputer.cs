using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �� �������� �������� ���� ������ ��� ������ � UI

public class OpenComputer : MonoBehaviour
{
    public GameObject computer;
    public Camera Camera;
    public GameObject ComputerCanvas;
    public GameObject ExitButton;

    private Animator mAnimator;
    private bool isOpen; // ��� ������������ ��������
    private bool isClosing; // ��� ������������ ��������� ��������

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        isOpen = false; // ���������� ��������� ������
        isClosing = false; // ���������� �� �����������
        ComputerCanvas.SetActive(false);
        ExitButton.SetActive(false);

        // ��������� ���������� ������� �� ������ ������
        ExitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��������� ������� ����� ������ ����
        {
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Computer"))
                {
                    if (!isOpen && !isClosing) // ���� ��������� ��� �� ������ � �� � �������� ��������
                    {
                        mAnimator.SetTrigger("TrgOpen");
                        isOpen = true; // ������������� ���� ��������
                    }
                }
            }
        }
    }

    // �����, ������� ����� ������ ��� ������� �� ������ ������
    private void OnExitButtonClick()
    {
        if (isOpen && !isClosing)
        {
            mAnimator.SetTrigger("TrgClose");
            isClosing = true; // ������������� ���� ��������
        }
    }

    // �����, ������� ����� ������ ��� ��������� �������� ��������
    public void OnOpenAnimationEnd()
    {
        Debug.Log("Open animation ended"); // ���������� ���������
        StartCoroutine(ShowCanvasAfterDelay(1.30f)); // �������� 1.30 ������
    }

    private IEnumerator ShowCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ComputerCanvas.SetActive(true);
        ExitButton.SetActive(true);
    }

    // �����, ������� ����� ������ ��� ��������� �������� ��������
    public void OnCloseAnimationEnd()
    {
        Debug.Log("Close animation ended"); // ���������� ���������
        ComputerCanvas.SetActive(false);
        ExitButton.SetActive(false);
        isOpen = false; // ���������� ���� ��������
        isClosing = false; // ���������� ���� ��������
    }
}

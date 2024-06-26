using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Не забудьте добавить этот импорт для работы с UI

public class OpenComputer : MonoBehaviour
{
    public GameObject computer;
    public Camera Camera;
    public GameObject ComputerCanvas;
    public GameObject ExitButton;

    private Animator mAnimator;
    private bool isOpen; // Для отслеживания открытия
    private bool isClosing; // Для отслеживания состояния закрытия

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        isOpen = false; // Изначально компьютер закрыт
        isClosing = false; // Изначально не закрывается
        ComputerCanvas.SetActive(false);
        ExitButton.SetActive(false);

        // Добавляем обработчик нажатия на кнопку выхода
        ExitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
        {
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Computer"))
                {
                    if (!isOpen && !isClosing) // Если компьютер еще не открыт и не в процессе закрытия
                    {
                        mAnimator.SetTrigger("TrgOpen");
                        isOpen = true; // Устанавливаем флаг открытия
                    }
                }
            }
        }
    }

    // Метод, который будет вызван при нажатии на кнопку выхода
    private void OnExitButtonClick()
    {
        if (isOpen && !isClosing)
        {
            mAnimator.SetTrigger("TrgClose");
            isClosing = true; // Устанавливаем флаг закрытия
        }
    }

    // Метод, который будет вызван при окончании анимации открытия
    public void OnOpenAnimationEnd()
    {
        Debug.Log("Open animation ended"); // Отладочное сообщение
        StartCoroutine(ShowCanvasAfterDelay(1.30f)); // Задержка 1.30 секунд
    }

    private IEnumerator ShowCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ComputerCanvas.SetActive(true);
        ExitButton.SetActive(true);
    }

    // Метод, который будет вызван при окончании анимации закрытия
    public void OnCloseAnimationEnd()
    {
        Debug.Log("Close animation ended"); // Отладочное сообщение
        ComputerCanvas.SetActive(false);
        ExitButton.SetActive(false);
        isOpen = false; // Сбрасываем флаг открытия
        isClosing = false; // Сбрасываем флаг закрытия
    }
}

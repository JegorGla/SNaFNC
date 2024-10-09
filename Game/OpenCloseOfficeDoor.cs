using UnityEngine;
using System.Collections;

public class OpenCloseOfficeDoor : MonoBehaviour
{
    public float distance = 3f;
    public Transform doorTransform; // Трансформ двери
    public Transform targetPoint1; // Позиция для открытой двери
    public Transform targetPoint2; // Позиция для закрытой двери
    public float moveSpeed = 10f; // Скорость движения двери

    public GameObject Button; // Объект кнопки
    public AudioSource Door; // Звуковой источник для двери

    private bool isOpen = false; // Состояние двери
    //private bool isInteracting = false; // Флаг для отслеживания взаимодействия с дверью

    public void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            // Проверяем, что нажата кнопка и она активна для взаимодействия
            if (hit.transform.gameObject == Button)
            {
                //isInteracting = true; // Устанавливаем флаг взаимодействия

                // Проверяем состояние двери перед переключением
                if (isOpen)
                {
                    Door.Play();
                    MoveDoorToTargetDown(targetPoint2.position);
                }
                else
                {
                    Door.Play();
                    MoveDoorToTargetUp(targetPoint1.position);
                }

                isOpen = !isOpen; // Переключаем состояние двери

                // После завершения анимации сбрасываем флаг взаимодействия
                StartCoroutine(ResetInteraction());
            }
        }
    }

    private void MoveDoorToTargetUp(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    private void MoveDoorToTargetDown(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    private IEnumerator MoveDoorCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(doorTransform.position, targetPosition) > 0.01f)
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        doorTransform.position = targetPosition;
    }

    private IEnumerator ResetInteraction()
    {
        // Ждём, пока дверь не достигнет целевой позиции
        while (Vector3.Distance(doorTransform.position, isOpen ? targetPoint1.position : targetPoint2.position) > 0.01f)
        {
            yield return null;
        }
        //isInteracting = false; // Сбрасываем флаг взаимодействия
    }
}

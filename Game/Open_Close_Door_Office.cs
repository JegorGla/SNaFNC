using UnityEngine;
using System.Collections;

public class OpenCloseDoorOffice : MonoBehaviour
{
    public float distance = 3f; // Максимальная дистанция для взаимодействия с дверью
    public Transform doorTransform; // Ссылка на Transform объекта двери
    public Transform targetPoint1; // Пустой объект, к которому перемещается дверь вверх
    public Transform targetPoint2; // Пустой объект, к которому перемещается дверь вниз
    public float moveSpeed = 10f; // Скорость перемещения двери к целевой точке

    public AudioSource Door;

    private bool isOpen = false; // Булевая переменная для отслеживания состояния двери

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.CompareTag("Button")) // Проверяем, что нажата кнопка у двери
            {
                isOpen = !isOpen; // Инвертируем состояние двери после выполнения действия

                if (isOpen)
                {
                    Door.Play();
                    MoveDoorToTargetUp(targetPoint1.position); // Запускаем перемещение двери к целевой точке вверх
                }
                else
                {
                    Door.Play();
                    MoveDoorToTargetDown(targetPoint2.position); // Запускаем перемещение двери к целевой точке вниз
                }
            }
        }
    }

    void MoveDoorToTargetUp(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    void MoveDoorToTargetDown(Vector3 targetPosition)
    {
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    IEnumerator MoveDoorCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(doorTransform.position, targetPosition) > 0.01f)
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        doorTransform.position = targetPosition;
    }
}

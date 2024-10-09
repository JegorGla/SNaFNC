using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public GameObject Player; // Объект игрока
    public float stopDuration = 10f; // Длительность остановки времени

    private List<Rigidbody> affectedRigidbodies = new List<Rigidbody>(); // Список объектов с физикой
    private List<Animator> affectedAnimators = new List<Animator>(); // Список объектов с анимацией

    public void StopTime()
    {
        StartCoroutine(TimeStopCoroutine());
    }

    private IEnumerator TimeStopCoroutine()
    {
        // Получаем все объекты в сцене
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Перебираем все объекты
        foreach (GameObject obj in allObjects)
        {
            if (obj == Player || obj.transform.IsChildOf(Player.transform))
            {
                continue;
            }

            // Отключаем физику
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                affectedRigidbodies.Add(rb);
            }

            // Отключаем анимацию
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
                affectedAnimators.Add(animator);
            }
        }

        // Ждем указанное время
        yield return new WaitForSecondsRealtime(stopDuration);

        // Возобновляем физику и анимацию
        foreach (Rigidbody rb in affectedRigidbodies)
        {
            rb.isKinematic = false;
        }
        affectedRigidbodies.Clear();

        foreach (Animator animator in affectedAnimators)
        {
            animator.enabled = true;
        }
        affectedAnimators.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInWood : MonoBehaviour
{
    public float distance = 3f;  // Максимальное расстояние для взаимодействия с дверью
    public float rotationSpeed = 2f; // Скорость поворота двери

    public AudioSource lockeddoor;
    public AudioSource opendoor;

    public List<GameObject> doors;  // Список всех дверей
    public List<GameObject> lockedDoors;  // Список всех запертых дверей

    // Вспомогательный класс для хранения состояния каждой двери
    private class DoorState
    {
        public GameObject door;
        public bool isOpen;

        public DoorState(GameObject door)
        {
            this.door = door;
            isOpen = false;
        }
    }

    private List<DoorState> doorStates = new List<DoorState>();

    void Start()
    {
        // Инициализируем состояние для всех дверей
        foreach (var door in doors)
        {
            doorStates.Add(new DoorState(door));
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, пересек ли луч объект с тегом "DoorInWood" и находится ли он в пределах расстояния
            if (Physics.Raycast(ray, out hit, distance) && hit.transform.CompareTag("DoorInWood"))
            {
                // Проверяем, не заблокирована ли дверь
                if (lockedDoors.Contains(hit.transform.gameObject))
                {
                    lockeddoor.Play();
                }

                foreach (var doorState in doorStates)
                {
                    if (doorState.door == hit.transform.gameObject)
                    {
                        opendoor.Play();
                        StartCoroutine(RotateDoor(doorState)); // Открываем или закрываем дверь
                        return;
                    }
                }
            }
        }
    }

    private IEnumerator RotateDoor(DoorState doorState)
    {
        float initialRotationY = doorState.door.transform.eulerAngles.y; // Начальная ротация по Y
        float targetRotationY;

        // Определяем направление поворота двери (открытие или закрытие)
        targetRotationY = doorState.isOpen ? initialRotationY - 90f : initialRotationY + 90f;

        // Плавный поворот двери
        Quaternion startRotation = doorState.door.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(doorState.door.transform.eulerAngles.x, targetRotationY, doorState.door.transform.eulerAngles.z);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed;
            doorState.door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        // Обновляем точное конечное значение ротации
        doorState.door.transform.rotation = endRotation;

        // Меняем состояние двери на противоположное
        doorState.isOpen = !doorState.isOpen;
    }
}

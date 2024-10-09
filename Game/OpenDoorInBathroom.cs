using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInBathroom : MonoBehaviour
{
    public List<GameObject> leftSideDoors;  // Двери с левой стороны, открывающиеся наружу
    public List<GameObject> rightSideDoors; // Двери с правой стороны, открывающиеся внутрь
    public float rotationSpeed = 2f; // Скорость поворота двери
    public float distance = 3f; // Максимальная дистанция для взаимодействия

    // Вспомогательный класс для хранения состояния каждой двери
    private class DoorState
    {
        public GameObject door;
        public bool isOpen;

        public Quaternion initialRotation;

        public DoorState(GameObject door)
        {
            this.door = door;
            isOpen = false;
            initialRotation = door.transform.rotation;
        }
    }

    private List<DoorState> leftSideDoorStates = new List<DoorState>();
    private List<DoorState> rightSideDoorStates = new List<DoorState>();

    void Start()
    {
        // Инициализируем состояние для дверей с левой стороны (наружу)
        foreach (var door in leftSideDoors)
        {
            leftSideDoorStates.Add(new DoorState(door));
        }

        // Инициализируем состояние для дверей с правой стороны (внутрь)
        foreach (var door in rightSideDoors)
        {
            rightSideDoorStates.Add(new DoorState(door));
        }
    }

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из позиции камеры вперед
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, пересек ли луч объект с тегом "Bathroom_toilet_door"
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Bathroom_toilet_door"))
                {
                    // Проверяем двери с левой стороны
                    foreach (var doorState in leftSideDoorStates)
                    {
                        if (doorState.door == hit.transform.gameObject)
                        {
                            StartCoroutine(RotateDoor(doorState, true)); // Открываем или закрываем дверь
                            break;
                        }
                    }

                    // Проверяем двери с правой стороны
                    foreach (var doorState in rightSideDoorStates)
                    {
                        if (doorState.door == hit.transform.gameObject)
                        {
                            StartCoroutine(RotateDoor(doorState, false)); // Открываем или закрываем дверь
                            break;
                        }
                    }
                }
            }
        }
    }

    // Корутина для поворота двери
    private IEnumerator RotateDoor(DoorState doorState, bool openOutwards)
    {
        float targetRotationY;

        if (openOutwards)
        {
            // Открытие наружу
            targetRotationY = doorState.isOpen ? doorState.initialRotation.eulerAngles.y : doorState.initialRotation.eulerAngles.y + 70f;
        }
        else
        {
            // Открытие внутрь
            targetRotationY = doorState.isOpen ? doorState.initialRotation.eulerAngles.y : doorState.initialRotation.eulerAngles.y - 70f;
        }

        Quaternion startRotation = doorState.door.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(doorState.initialRotation.eulerAngles.x, targetRotationY, doorState.initialRotation.eulerAngles.z);

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

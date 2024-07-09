using UnityEngine;
using System.Collections;

public class Take : MonoBehaviour
{
    float distance = 3f;
    public Transform pos1; // Новая позиция для объекта перед камерой
    public Transform pos2;
    public Transform cameraPosition; // Новая позиция для камеры
    private Rigidbody rb;

    public GameObject Vino;
    public BackPack backPack;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        backPack = Object.FindAnyObjectByType<BackPack>();
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.tag == "Vino")
            {
                StartCoroutine(MoveToCameraThenPos2(hit.transform.gameObject));
            }
        }
    }

    IEnumerator MoveToCameraThenPos2(GameObject vinoObject)
    {
        rb.isKinematic = true;

        // Двигаем объект к камере
        float duration = 0.5f;
        float timer = 0f;
        Vector3 startPosition = vinoObject.transform.position;
        Vector3 targetPosition = cameraPosition.position;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            vinoObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // Задержка 2 секунды перед опусканием
        yield return new WaitForSeconds(2);

        // Теперь двигаем объект от камеры к pos2
        duration = 0.5f;
        timer = 0f;
        startPosition = vinoObject.transform.position;
        targetPosition = pos2.position;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            vinoObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        rb.isKinematic = false;

        // Удаляем объект и активируем Vino в BackPack только после успешного перемещения
        PickableItem item = vinoObject.GetComponent<PickableItem>();
        if (item != null)
        {
            backPack.AddItemToBackPack(item.itemSprite);
        }
        Destroy(vinoObject);
    }
}

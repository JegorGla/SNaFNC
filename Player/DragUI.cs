using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform movableImage;
    private Vector2 originalPosition;

    void Start()
    {
        // Сохраняем исходное положение
        originalPosition = movableImage.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Сохраняем смещение от начального положения до позиции курсора мыши
        Vector2 delta = eventData.position - (Vector2)movableImage.position;
        // Сохраняем начальное положение
        originalPosition = movableImage.anchoredPosition - delta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Устанавливаем позицию элемента равной позиции курсора мыши
        movableImage.anchoredPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Возвращаем элемент в исходное положение
        movableImage.anchoredPosition = originalPosition;
    }
}

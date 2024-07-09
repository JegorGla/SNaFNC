using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform movableImage;
    private Vector2 originalPosition;

    void Start()
    {
        // ��������� �������� ���������
        originalPosition = movableImage.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ��������� �������� �� ���������� ��������� �� ������� ������� ����
        Vector2 delta = eventData.position - (Vector2)movableImage.position;
        // ��������� ��������� ���������
        originalPosition = movableImage.anchoredPosition - delta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ������������� ������� �������� ������ ������� ������� ����
        movableImage.anchoredPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ���������� ������� � �������� ���������
        movableImage.anchoredPosition = originalPosition;
    }
}

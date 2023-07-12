using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gogobus55Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 startPos; // ���� ��ġ
    private Vector2 originPos; // �ʱ�ȭ ��ġ
    private Vector2 originSize; // ���� ũ��

    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // ���� ��ġ ����
        originSize = GetComponent<RectTransform>().sizeDelta; // ���� ũ�� ���� 
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // ���� ��ġ �ʱ�ȭ
    }

    // �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // ���� ��ġ
        this.transform.position = currentPos; // ���� ī���� ��ġ�� ���� ��ġ�� ����
    }

    // �巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

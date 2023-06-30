using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToAnswer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static Vector2 startPos; // ���� ��ġ
    private Vector2 originPos; // �ʱ�ȭ ��ġ

    public List<Image> answerSprite = new List<Image>(); // �亯 ī�� �̹���
    public float detectRange; // ���� ����

    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // �亯 ī�� ��ġ �ʱ�ȭ
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // ���� ��ġ �ʱ�ȭ
    }

    // �巡�� ��
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // ���� ��ġ
        this.transform.position = currentPos; // �亯 ī���� ��ġ�� ���� ��ġ�� ����
    }

    // �巡�� ����
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // ����ī�޶��� ȭ�鿡�� ���콺 Ŀ���� ��ġ�� ��´�
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}

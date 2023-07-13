using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gogobus8Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float detectRange;
    public static Vector2 startPos; // ���� ��ġ
    public Gogobus8Success successObj;
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

        int layerMask = 1 << 6; // ���̾�6 �����ϱ�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            if (eventData.pointerEnter.GetComponent<Gogobus8Value>().value == hits[0].collider.GetComponent<Gogobus8Value>().value)
            {
                GetComponent<RectTransform>().position = new Vector3(hits[0].transform.position.x, hits[0].transform.position.y, hits[0].transform.position.z);
                successObj.IncreaseCount();
                Destroy(GetComponent<Gogobus8Drag>());
            }
            else
            {
                GetComponent<RectTransform>().position = originPos;
            }
        }
    }
}

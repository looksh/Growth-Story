using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gogobus55Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 startPos; // 시작 위치
    private Vector2 originPos; // 초기화 위치
    private Vector2 originSize; // 원래 크기

    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // 원래 위치 저장
        originSize = GetComponent<RectTransform>().sizeDelta; // 원래 크기 저장 
    }

    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // 시작 위치 초기화
    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // 현재 위치
        this.transform.position = currentPos; // 숫자 카드의 위치를 현재 위치로 지정
    }

    // 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

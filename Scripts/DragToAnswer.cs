using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToAnswer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static Vector2 startPos; // 시작 위치
    private Vector2 originPos; // 초기화 위치

    public List<Image> answerSprite = new List<Image>(); // 답변 카드 이미지
    public float detectRange; // 감지 범위

    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // 답변 카드 위치 초기화
    }

    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // 시작 위치 초기화
    }

    // 드래그 중
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // 현재 위치
        this.transform.position = currentPos; // 답변 카드의 위치를 현재 위치로 지정
    }

    // 드래그 종료
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // 메인카메라의 화면에서 마우스 커서의 위치를 담는다
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}

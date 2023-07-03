using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum InAndOut
{
    Fit, UnFit
}


public class DragToAnswer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public MathManager manager;
    public ValueManager valueManager;

    public static Vector2 startPos; // 시작 위치
    private Vector2 originPos; // 초기화 위치
    private Vector2 originSize; // 원래 크기
    public float detectRange; // 감지 범위
    public InAndOut inAndOut = InAndOut.UnFit;


    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // 답변 카드 위치 초기화
        originSize = GetComponent<RectTransform>().sizeDelta; // 원래 크기 저장
    }

    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // 시작 위치 초기화

        GetComponent<RectTransform>().sizeDelta = originSize; // 원래 크기로

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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Transform objTransform = eventData.pointerEnter.transform;
        string objName = eventData.pointerEnter.name;
        
        int layerMask = 1 << 6; // 6번 레이어

        var hits = Physics.SphereCastAll(transform.position,
            detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                GameObject detect = hit.collider.gameObject;

                if (objName != "equal" && objName != "plus")
                {
                    if ((detect.name == "sumAnswer") || (detect.name != "equalAnswer" && detect.name != "plusAnswer"))
                    {
                        objTransform.position = new Vector3(detect.transform.position.x, detect.transform.position.y, detect.transform.position.z);
                        objTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                        inAndOut = InAndOut.Fit;

                        if (detect.name != "sumAnswer")
                        {
                            valueManager.ReceiveValue(eventData.pointerEnter.GetComponent<ValueManager>().value);
                            inAndOut = InAndOut.Fit;
                        }
                    }
                }
                else
                {
                    if ((detect.name == "equalAnswer" && objName == "equal") || (detect.name == "plusAnswer" && objName == "plus"))
                    {
                        objTransform.position = new Vector3(detect.transform.position.x, detect.transform.position.y, detect.transform.position.z);
                        objTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                        inAndOut = InAndOut.Fit;
                    }
                }
            }

            // 조건. 모든 selectCard의 상태가 Fit 상태여야한다.

            // sumAnswer 로 들어가는 값이

            // sum 의 값과 다르다면 모두 초기화.




            if (GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut != InAndOut.UnFit)
            {
                if (GameObject.Find("sum").GetComponent<ValueManager>().value != valueManager.reserveValue)
                {
                    valueManager.reserveValue = 0;
                    Debug.Log("초기화함: " + valueManager.reserveValue);

                    GetComponent<RectTransform>().position = originPos;
                    GetComponent<RectTransform>().sizeDelta = originSize; // 원래 크기로
                }
            }
        }
    }
}

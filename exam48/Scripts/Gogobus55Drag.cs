using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gogobus55Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 startPos; // 시작 위치
    public float detectRange;
    public Gogobus55SuccessCount successObj;
    public Gogobus55Image img;
    public GameClearController gameClearController;
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

        int layerMask = 1 << 6; // 레이어6 감지하기
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        Gogobus55State pointerState = eventData.pointerEnter.transform.GetComponent<Gogobus55State>();

        if (hits.Length > 0)
        {
            Gogobus55State detectState = hits[0].transform.GetComponent<Gogobus55State>();

            // 포인터의 상태와 감지된 물체의 상태가 같다면 정답처리
            if (detectState.state == pointerState.state)
            {
                GetComponent<RectTransform>().position = new Vector3(hits[0].transform.position.x, hits[0].transform.position.y, hits[0].transform.position.z);
                successObj.IncreseCount();

                if (successObj.GetSuccessCount() == 2)
                {
                    img.ChangeImg();
                    StartCoroutine(SuccessGame());
                }
            }
            else
            {
                Debug.Log("실패");
                GetComponent<RectTransform>().position = originPos;
            }
        }
    }

    IEnumerator SuccessGame()
    {
        yield return new WaitForSeconds(2.0f);
        gameClearController.UpdateClearCount();
    }
}

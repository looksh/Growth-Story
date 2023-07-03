using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerDetect : MonoBehaviour
{
    public float detectRange; // 감지 범위
    public GameObject answerCard;
    public MathManager manager;
    public ValueManager valueManager;

    void Update()
    {
        //Detect();
    }

    // 1. 감지되면 숫자 카드의 값을 전달받을 수 있도록 해야한다.
    // 2. 모든 숫자 카드 전부 들어올 수 있도록 만들어야한다.

    public void Detect()
    {
        int layerMask = 1 << 6; // 6번 레이어

        var hits = Physics.SphereCastAll(transform.position,
            detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                GameObject selectCard = hit.collider.gameObject;

                if (hit.collider.gameObject.name != "equal" && hit.collider.gameObject.name != "plus")
                {
                    // 감지된 숫자 카드의 값을 ValueManager로 전달
                    valueManager.ReceiveValue(hit.collider.GetComponent<ValueManager>().value);
                    selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                }
                else
                {
                    //// equal 이면 equalAnswer 에 붙고 plus 이면 plusAnswer에 붙기
                    //switch (hit.collider.gameObject.name)
                    //{
                    //    case "equal":

                    //        {
                    //            selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    //            selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                    //            break;
                    //        }
                    //    case "plus":
                    //        {
                    //            selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    //            selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                    //            break;
                    //        }
                    //}
                }
            }
        }

        //if (hits.Length > 0 )
        //{
        //    bool isSelectCardMatched = false; // selectCard.name과 일치하는지 여부를 저장하는 변수
        //    foreach (var hit in hits)
        //    {
        //        if (hit.collider.gameObject.name == selectCard.name)
        //        {
        //            isSelectCardMatched = true;
        //            break;
        //        }
        //    }

        //    if (isSelectCardMatched)
        //    {
        //        // selectCard.name과 일치하면 선택 카드 이동 및 크기 변경
        //selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
        //selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
        //    }
        //}
    }

    // 기즈모를 그리는 함수
    public void OnDrawGizmos()
    {
        // 와이어 스피어를 그린다. (그릴위치, 반지름)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}

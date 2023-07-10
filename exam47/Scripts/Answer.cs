using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Answer : MonoBehaviour
{
    public string value = "";
    public float detectRange;
    public GameObject failedText;
    public GameObject answer;
    public LaundryBoard laundryBoard;
    public GameClearController gameClearController;
    

    private void Start()
    {
        StartCoroutine(SetValue());
    }

    // 런타임에 세탁기 함수가 실행되면 값 저장하는 함수
    private IEnumerator SetValue()
    {
        yield return new WaitUntil(() => laundryBoard.IsFuncExec == true);
        value = laundryBoard.GetRandomCountS();
        Debug.Log(value);
    }

    // 정답 확인하는 함수
    public void IsCorrect(PointerEventData eventData)
    {
        int layerMask = 1 << 6; // 레이어6 감지하기
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                string hitName = hit.collider.gameObject.name;

                if (hitName == answer.GetComponent<Answer>().value)
                {
                    SuccessGame();
                }
                else
                {
                    StartCoroutine(FailedGame());
                }
            }
        }
    }

    void SuccessGame()
    {
        gameClearController.UpdateClearCount();
    }

    IEnumerator FailedGame()
    {
        failedText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        failedText.SetActive(false);
    }

}

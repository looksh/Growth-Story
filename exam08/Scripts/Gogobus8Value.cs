using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus8Value : MonoBehaviour
{
    public GameObject answer;
    public Gogobus8Notice notice;
    public bool excuted;
    public int value;

    private void Start()
    {
        StartCoroutine(SetValue());
    }

    // 위치에 맞는 값을 부여
    IEnumerator SetValue()
    {
        yield return new WaitUntil(() => notice.isExcute == true);     

        switch (answer.name)
        {
            case "Num1Answer":
                {
                    value = notice.ReturnNum1(); break;
                }
            case "Num2Answer":
                {
                    value = notice.ReturnNum2(); break;
                }
            case "SumAnswer":
                {
                    value = notice.ReturnSum(); break;
                }
            case "PlusAnswer":
                {
                    value = 10; break;
                }
            case "EqualAnswer":
                {
                    value = 11; break;
                }
        }
        excuted = true;
    }
}

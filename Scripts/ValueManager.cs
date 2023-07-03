using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public MathManager manager;
    public GameObject selectCard = null;

    public int value;
    public int reserveValue = 0;

    void Start()
    {
        StartCoroutine(getValue());
    }

    IEnumerator getValue()
    {
        yield return new WaitForSeconds(0.1f);
        switch (selectCard.name)
        {
            case "first":
                {
                    value = manager.firstNumber;
                    break;
                }
            case "second":
                {
                    value = manager.secondNumber;
                    break;
                }
            case "sum":
                {
                    value = manager.sum;
                    break;
                }
        }
    }

    // 감지된 값 전달 받는 함수
    public void ReceiveValue(int detectedValue)
    {
        reserveValue += detectedValue;
        // 감지된 값에 대한 처리 로직 작성
        Debug.Log("Received value: " + reserveValue);
    }

    //public void ResetValue(int detectedValue)
    //{
    //    reserveValue -= detectedValue;
    //    Debug.Log("Reset value: " + reserveValue);
    //}
}

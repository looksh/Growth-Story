using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus67Value : MonoBehaviour
{
    public Gogobus67Plate plate;
    public Gogobus67ImageChanger imageChanger;
    public GameClearController clearController;
    public GameObject card;

    public int disappearValue; // 사라진 값
    public int resultValue; // 10-사라진 값 계산 결과

    private void Start()
    {
        StartCoroutine(SetValue());
    }

    IEnumerator SetValue()
    {
        yield return new WaitUntil( () => plate.isExcute == true);
        card.GetComponent<Gogobus67Value>().disappearValue = plate.ReturnDisappearCount();
        resultValue = 10 - disappearValue;
        imageChanger.ImageChange();
    }

    public int Result()
    {
        return resultValue;
    }

    public void Success()
    {
        clearController.UpdateClearCount();
    }

    //public void OnClick()
    //{
    //    Debug.Log("number.value: " + number.value);
    //    Debug.Log("Result(): " + Result());
    //    if (number.value == Result())
    //    {
    //        clearController.UpdateClearCount();
    //    }
    //    else
    //    {
    //        Debug.Log("틀렸어용");
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus67Value : MonoBehaviour
{
    public Gogobus67Plate plate;
    public Gogobus67ImageChanger imageChanger;
    public Gogobus67Number number;
    public GameClearController clearController;
    public GameObject card;

    public int disappearValue;
    public int resultValue;

    private void Start()
    {
        StartCoroutine(SetValue());
    }

    IEnumerator SetValue()
    {
        yield return new WaitUntil( () => plate.isExcute == true);
        card.GetComponent<Gogobus67Value>().disappearValue = disappearValue;
        resultValue = 10 - disappearValue;
        imageChanger.ImageChange();
    }

    int Result()
    {
        return resultValue;
    }

    public void OnClick()
    {
        Debug.Log(number.value);
        Debug.Log("위: number.value, 아래: resultValue");
        Debug.Log(Result());

        if(number.value == Result())
        {
            clearController.UpdateClearCount();
        }
        else
        {
            Debug.Log("틀렸어용");
        }
    }
}

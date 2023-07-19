using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gogobus67Number : MonoBehaviour
{
    public GameObject numberCard;
    public Gogobus67Value gogobus67Value;
    public int value;

    public void OnClick()
    {
        Debug.Log("number.value: " + value);
        Debug.Log("Result(): " + gogobus67Value.Result());
        if (value == gogobus67Value.Result())
        {
            gogobus67Value.Success();
        }
        else
        {
            Debug.Log("Æ²·È¾î¿ë");
        }
    }
}

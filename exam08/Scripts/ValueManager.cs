using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public MathManager manager;
    public GameObject selectCard = null;

    public int value;
    public int reserveValue = 0;

    public void Start()
    {
        StartCoroutine(getValue());
    }

    IEnumerator getValue()
    {
        yield return new WaitForSeconds(0.1f);

        if (selectCard != null )
        {
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
    }

    public void ReceiveValue(int detectedValue)
    {
        reserveValue += detectedValue;
    }

    public void ResetValue()
    {
        reserveValue = 0;
    }

    public void ReduceValue(int detectedValue)
    {
        reserveValue -= detectedValue;
    }
}

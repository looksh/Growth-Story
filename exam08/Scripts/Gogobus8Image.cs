using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gogobus8Image : MonoBehaviour
{
    public Gogobus8Value value;
    public ShuffleChildren shuffle;

    public GameObject parent;
    public GameObject num1Answer;
    public GameObject num2Answer;
    public GameObject sumAnswer;

    public Sprite numOne;
    public Sprite numTwo;
    public Sprite numThree;
    public Sprite numFour;
    public Sprite numFive;
    public Sprite numSix;
    public Sprite numSeven;
    public Sprite numEight;
    public Sprite numNine;

    private void Start()
    {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        yield return new WaitUntil(() => value.excuted == true);
        Debug.Log(num1Answer.GetComponent<Gogobus8Value>().value);
        switch (num1Answer.GetComponent<Gogobus8Value>().value)
        {
            case 1:
                {
                    num1Answer.GetComponent<Image>().sprite = numOne; break;
                }
            case 2:
                {
                    num1Answer.GetComponent<Image>().sprite = numTwo; break;
                }
            case 3:
                {
                    num1Answer.GetComponent<Image>().sprite = numThree; break;
                }
            case 4:
                {
                    num1Answer.GetComponent<Image>().sprite = numFour; break;
                }
            case 5:
                {
                    num1Answer.GetComponent<Image>().sprite = numFive; break;
                }
            case 6:
                {
                    num1Answer.GetComponent<Image>().sprite = numSix; break;
                }
            case 7:
                {
                    num1Answer.GetComponent<Image>().sprite = numSeven; break;
                }
            case 8:
                {
                    num1Answer.GetComponent<Image>().sprite = numEight; break;
                }
            case 9:
                {
                    num1Answer.GetComponent<Image>().sprite = numNine; break;
                }
        }
        Debug.Log(num2Answer.GetComponent<Gogobus8Value>().value);
        switch (num2Answer.GetComponent<Gogobus8Value>().value)
        {
            case 1:
                {
                    num2Answer.GetComponent<Image>().sprite = numOne; break;
                }
            case 2:
                {
                    num2Answer.GetComponent<Image>().sprite = numTwo; break;
                }
            case 3:
                {
                    num2Answer.GetComponent<Image>().sprite = numThree; break;
                }
            case 4:
                {
                    num2Answer.GetComponent<Image>().sprite = numFour; break;
                }
            case 5:
                {
                    num2Answer.GetComponent<Image>().sprite = numFive; break;
                }
            case 6:
                {
                    num2Answer.GetComponent<Image>().sprite = numSix; break;
                }
            case 7:
                {
                    num2Answer.GetComponent<Image>().sprite = numSeven; break;
                }
            case 8:
                {
                    num2Answer.GetComponent<Image>().sprite = numEight; break;
                }
            case 9:
                {
                    num2Answer.GetComponent<Image>().sprite = numNine; break;
                }
        }
        Debug.Log(sumAnswer.GetComponent<Gogobus8Value>().value);
        switch (sumAnswer.GetComponent<Gogobus8Value>().value)
        {
            case 1:
                {
                    sumAnswer.GetComponent<Image>().sprite = numOne; break;
                }
            case 2:
                {
                    sumAnswer.GetComponent<Image>().sprite = numTwo; break;
                }
            case 3:
                {
                    sumAnswer.GetComponent<Image>().sprite = numThree; break;
                }
            case 4:
                {
                    sumAnswer.GetComponent<Image>().sprite = numFour; break;
                }
            case 5:
                {
                    sumAnswer.GetComponent<Image>().sprite = numFive; break;
                }
            case 6:
                {
                    sumAnswer.GetComponent<Image>().sprite = numSix; break;
                }
            case 7:
                {
                    sumAnswer.GetComponent<Image>().sprite = numSeven; break;
                }
            case 8:
                {
                    sumAnswer.GetComponent<Image>().sprite = numEight; break;
                }
            case 9:
                {
                    sumAnswer.GetComponent<Image>().sprite = numNine; break;
                }
        }
        shuffle.Shuffle();
        //Destroy(parent.GetComponent<HorizontalLayoutGroup>());
    }
}

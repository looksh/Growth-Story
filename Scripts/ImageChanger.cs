using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public GameObject img;
    public GameObject img2;
    public GameObject img3;
    public MathManager manager;

    public Sprite numOne;
    public Sprite numTwo;
    public Sprite numThree;
    public Sprite numFour;
    public Sprite numFive;
    public Sprite numSix;
    public Sprite numSeven;
    public Sprite numEight;
    public Sprite numNine;
    public Sprite numZero;


    public void OnFirstStateChange()
    {
        // State 값에 따라 이미지를 변경
        switch (manager.firstState)
        {
            case SelectState.ZERO:
                img.GetComponent<Image>().sprite = numZero; // 숫자 0에 해당하는 이미지로 변경
                break;
            case SelectState.ONE:
                img.GetComponent<Image>().sprite = numOne; // 숫자 1에 해당하는 이미지로 변경
                break;
            case SelectState.TWO:
                img.GetComponent<Image>().sprite = numTwo; // 숫자 2에 해당하는 이미지로 변경
                break;
            case SelectState.THREE:
                img.GetComponent<Image>().sprite = numThree; // 숫자 3에 해당하는 이미지로 변경
                break;
            case SelectState.FOUR:
                img.GetComponent<Image>().sprite = numFour; // 숫자 4에 해당하는 이미지로 변경
                break;
            case SelectState.FIVE:
                img.GetComponent<Image>().sprite = numFive; // 숫자 5에 해당하는 이미지로 변경
                break;
            case SelectState.SIX:
                img.GetComponent<Image>().sprite = numSix; // 숫자 6에 해당하는 이미지로 변경
                break;
            case SelectState.SEVEN:
                img.GetComponent<Image>().sprite = numSeven; // 숫자 7에 해당하는 이미지로 변경
                break;
            case SelectState.EIGHT:
                img.GetComponent<Image>().sprite = numEight; // 숫자 8에 해당하는 이미지로 변경
                break;
            case SelectState.NINE:
                img.GetComponent<Image>().sprite = numNine; // 숫자 9에 해당하는 이미지로 변경
                break;
        }
        switch (manager.secondState)
        {
            case SelectState.ZERO:
                img2.GetComponent<Image>().sprite = numZero; // 숫자 0에 해당하는 이미지로 변경
                break;
            case SelectState.ONE:
                img2.GetComponent<Image>().sprite = numOne; // 숫자 1에 해당하는 이미지로 변경
                break;
            case SelectState.TWO:
                img2.GetComponent<Image>().sprite = numTwo; // 숫자 2에 해당하는 이미지로 변경
                break;
            case SelectState.THREE:
                img2.GetComponent<Image>().sprite = numThree; // 숫자 3에 해당하는 이미지로 변경
                break;
            case SelectState.FOUR:
                img2.GetComponent<Image>().sprite = numFour; // 숫자 4에 해당하는 이미지로 변경
                break;
            case SelectState.FIVE:
                img2.GetComponent<Image>().sprite = numFive; // 숫자 5에 해당하는 이미지로 변경
                break;
            case SelectState.SIX:
                img2.GetComponent<Image>().sprite = numSix; // 숫자 6에 해당하는 이미지로 변경
                break;
            case SelectState.SEVEN:
                img2.GetComponent<Image>().sprite = numSeven; // 숫자 7에 해당하는 이미지로 변경
                break;
            case SelectState.EIGHT:
                img2.GetComponent<Image>().sprite = numEight; // 숫자 8에 해당하는 이미지로 변경
                break;
            case SelectState.NINE:
                img2.GetComponent<Image>().sprite = numNine; // 숫자 9에 해당하는 이미지로 변경
                break;
        }
        switch (manager.sumState)
        {
            case SelectState.ZERO:
                img3.GetComponent<Image>().sprite = numZero; // 숫자 0에 해당하는 이미지로 변경
                break;
            case SelectState.ONE:
                img3.GetComponent<Image>().sprite = numOne; // 숫자 1에 해당하는 이미지로 변경
                break;
            case SelectState.TWO:
                img3.GetComponent<Image>().sprite = numTwo; // 숫자 2에 해당하는 이미지로 변경
                break;
            case SelectState.THREE:
                img3.GetComponent<Image>().sprite = numThree; // 숫자 3에 해당하는 이미지로 변경
                break;
            case SelectState.FOUR:
                img3.GetComponent<Image>().sprite = numFour; // 숫자 4에 해당하는 이미지로 변경
                break;
            case SelectState.FIVE:
                img3.GetComponent<Image>().sprite = numFive; // 숫자 5에 해당하는 이미지로 변경
                break;
            case SelectState.SIX:
                img3.GetComponent<Image>().sprite = numSix; // 숫자 6에 해당하는 이미지로 변경
                break;
            case SelectState.SEVEN:
                img3.GetComponent<Image>().sprite = numSeven; // 숫자 7에 해당하는 이미지로 변경
                break;
            case SelectState.EIGHT:
                img3.GetComponent<Image>().sprite = numEight; // 숫자 8에 해당하는 이미지로 변경
                break;
            case SelectState.NINE:
                img3.GetComponent<Image>().sprite = numNine; // 숫자 9에 해당하는 이미지로 변경
                break;
        }
    }
}

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
        // State ���� ���� �̹����� ����
        switch (manager.firstState)
        {
            case SelectState.ZERO:
                img.GetComponent<Image>().sprite = numZero; // ���� 0�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.ONE:
                img.GetComponent<Image>().sprite = numOne; // ���� 1�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.TWO:
                img.GetComponent<Image>().sprite = numTwo; // ���� 2�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.THREE:
                img.GetComponent<Image>().sprite = numThree; // ���� 3�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FOUR:
                img.GetComponent<Image>().sprite = numFour; // ���� 4�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FIVE:
                img.GetComponent<Image>().sprite = numFive; // ���� 5�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SIX:
                img.GetComponent<Image>().sprite = numSix; // ���� 6�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SEVEN:
                img.GetComponent<Image>().sprite = numSeven; // ���� 7�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.EIGHT:
                img.GetComponent<Image>().sprite = numEight; // ���� 8�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.NINE:
                img.GetComponent<Image>().sprite = numNine; // ���� 9�� �ش��ϴ� �̹����� ����
                break;
        }
        switch (manager.secondState)
        {
            case SelectState.ZERO:
                img2.GetComponent<Image>().sprite = numZero; // ���� 0�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.ONE:
                img2.GetComponent<Image>().sprite = numOne; // ���� 1�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.TWO:
                img2.GetComponent<Image>().sprite = numTwo; // ���� 2�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.THREE:
                img2.GetComponent<Image>().sprite = numThree; // ���� 3�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FOUR:
                img2.GetComponent<Image>().sprite = numFour; // ���� 4�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FIVE:
                img2.GetComponent<Image>().sprite = numFive; // ���� 5�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SIX:
                img2.GetComponent<Image>().sprite = numSix; // ���� 6�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SEVEN:
                img2.GetComponent<Image>().sprite = numSeven; // ���� 7�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.EIGHT:
                img2.GetComponent<Image>().sprite = numEight; // ���� 8�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.NINE:
                img2.GetComponent<Image>().sprite = numNine; // ���� 9�� �ش��ϴ� �̹����� ����
                break;
        }
        switch (manager.sumState)
        {
            case SelectState.ZERO:
                img3.GetComponent<Image>().sprite = numZero; // ���� 0�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.ONE:
                img3.GetComponent<Image>().sprite = numOne; // ���� 1�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.TWO:
                img3.GetComponent<Image>().sprite = numTwo; // ���� 2�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.THREE:
                img3.GetComponent<Image>().sprite = numThree; // ���� 3�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FOUR:
                img3.GetComponent<Image>().sprite = numFour; // ���� 4�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.FIVE:
                img3.GetComponent<Image>().sprite = numFive; // ���� 5�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SIX:
                img3.GetComponent<Image>().sprite = numSix; // ���� 6�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.SEVEN:
                img3.GetComponent<Image>().sprite = numSeven; // ���� 7�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.EIGHT:
                img3.GetComponent<Image>().sprite = numEight; // ���� 8�� �ش��ϴ� �̹����� ����
                break;
            case SelectState.NINE:
                img3.GetComponent<Image>().sprite = numNine; // ���� 9�� �ش��ϴ� �̹����� ����
                break;
        }
    }
}

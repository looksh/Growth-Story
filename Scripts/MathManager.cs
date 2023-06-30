using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum SelectState
{
    ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, NONE
}

public class MathManager : MonoBehaviour
{
    public int firstNumber;
    public int secondNumber;
    public int sum;

    public string nonParticle; // �� ��
    public string objParticle; // �� ��

    public Text noticeText; // ���� �ؽ�Ʈ

    public SelectState firstState = SelectState.NONE;
    public SelectState secondState = SelectState.NONE;
    public SelectState sumState = SelectState.NONE;

    public ImageChanger imgChanger;

    void Start()
    {
        RandomNotice();
    }

    public void RandomNotice()
    {
        // �� �������� ����
        firstNumber = Random.Range(0, 9);
        secondNumber = Random.Range(0, 9);

        while (firstNumber + secondNumber >= 10)
        {
            firstNumber = Random.Range(0, 9);
            secondNumber = Random.Range(0, 9);
        }

        sumCalc(firstNumber, secondNumber);
    }

    public void sumCalc(int a, int b)
    {
        sum = a + b;
        stateChanger();
        imgChanger.OnFirstStateChange();
        syntaxChanger();
        noticeText.text = $"{firstNumber} ���ϱ� {secondNumber}{nonParticle} {sum}{objParticle} �����ϴ�.";
    }

    public void syntaxChanger()
    {
        nonParticle = (secondNumber == 0 || secondNumber == 1 || secondNumber == 3 || secondNumber == 6 || secondNumber == 7 || secondNumber == 8) ? "��" : "��";
        objParticle = (sum == 0 || sum == 1 || sum == 3 || sum == 6 || sum == 7 || sum == 8) ? "��" : "��";
    }


    public void stateChanger()
    {

        firstState = (SelectState)firstNumber;
        secondState = (SelectState)secondNumber;
        sumState = (SelectState)sum;
    }
}

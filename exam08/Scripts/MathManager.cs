using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject resultText;
    public GameObject failedText;

    public ImageChanger imgChanger;
    public ValueManager valueManager;
    public GameClearController gameClearController;

    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 sumPos;
    private Vector2 plusPos;
    private Vector2 equalPos;

    private Vector2 firstSize;
    private Vector2 secondSize;
    private Vector2 sumSize;
    private Vector2 plusSize;
    private Vector2 equalSize;

    private Vector2 originPos; // �ʱ�ȭ ��ġ
    private Vector2 originSize; // ���� ũ��

    private void Awake()
    {
        firstPos = GameObject.Find("first").GetComponent<RectTransform>().position;
        secondPos = GameObject.Find("second").GetComponent<RectTransform>().position;
        sumPos = GameObject.Find("sum").GetComponent<RectTransform>().position;
        plusPos = GameObject.Find("plus").GetComponent<RectTransform>().position;
        equalPos = GameObject.Find("equal").GetComponent<RectTransform>().position;

        firstSize = GameObject.Find("first").GetComponent<RectTransform>().sizeDelta;
        secondSize = GameObject.Find("second").GetComponent<RectTransform>().sizeDelta;
        sumSize = GameObject.Find("sum").GetComponent<RectTransform>().sizeDelta;
        plusSize = GameObject.Find("plus").GetComponent<RectTransform>().sizeDelta;
        equalSize = GameObject.Find("equal").GetComponent<RectTransform>().sizeDelta;
    }

    void Start()
    {
        RandomNotice();
    }

    private void Update()
    {

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
        sum = firstNumber + secondNumber;

        firstState = (SelectState)firstNumber;
        secondState = (SelectState)secondNumber;
        sumState = (SelectState)sum;

        imgChanger.OnFirstStateChange();
        SyntaxChanger();
        noticeText.text = $"{firstNumber} ���ϱ� {secondNumber}{nonParticle} {sum}{objParticle} �����ϴ�.";
    }

    public void SyntaxChanger()
    {
        nonParticle = (secondNumber == 0 || secondNumber == 1 || secondNumber == 3 || secondNumber == 6 || secondNumber == 7 || secondNumber == 8) ? "��" : "��";
        objParticle = (sum == 0 || sum == 1 || sum == 3 || sum == 6 || sum == 7 || sum == 8) ? "��" : "��";
    }

    void SuccessGame()
    {
        gameClearController.UpdateClearCount();
    }

    
    public void MathResult()
    {
        // ��� ��ü�� Fit���� �˻�
        if (GameObject.Find("first").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("second").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("plus").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("equal").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit)
        {
            // ���⼭ ������ �´��� �˻�
            if (GameObject.Find("sum").GetComponent<ValueManager>().value == valueManager.reserveValue)
            {
                // ����
                //StartCoroutine(Result());
                Debug.Log("�Ѿ��");
                SuccessGame();
            }
            else
            {
                // ����
                valueManager.ResetValue();
                StartCoroutine(Failed());
            }
        }
    }

    void ResetTransform()
    {
        GameObject.Find("first").GetComponent<RectTransform>().position = firstPos;
        GameObject.Find("second").GetComponent<RectTransform>().position = secondPos;
        GameObject.Find("sum").GetComponent<RectTransform>().position = sumPos;
        GameObject.Find("plus").GetComponent<RectTransform>().position = plusPos;
        GameObject.Find("equal").GetComponent<RectTransform>().position = equalPos;

        GameObject.Find("first").GetComponent<RectTransform>().sizeDelta = firstSize;
        GameObject.Find("second").GetComponent<RectTransform>().sizeDelta = secondSize;
        GameObject.Find("sum").GetComponent<RectTransform>().sizeDelta = sumSize;
        GameObject.Find("plus").GetComponent<RectTransform>().sizeDelta = plusSize;
        GameObject.Find("equal").GetComponent<RectTransform>().sizeDelta = equalSize;

        GameObject.Find("first").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("second").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("plus").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("equal").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
    }

    IEnumerator Result()
    {
        //resultText.SetActive(true);
        yield return new WaitForSeconds(2.0f); 
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(0.5f);
        failedText.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        ResetTransform();
        failedText.SetActive(false);
    }
}

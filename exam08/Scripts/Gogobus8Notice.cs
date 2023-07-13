using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gogobus8Notice : MonoBehaviour
{
    public Text noticeText;
    public bool isExcute;
    private int num1;
    private int num2;
    private int sum;
    private string nonParticle; // 은 는
    private string objParticle; // 와 과

    private void Start()
    {
        CreateNotice();
    }

    // 수학 문제 생성기
    void CreateNotice()
    {
        // 난수 생성하기
        num1 = Random.Range(1, 9);
        num2 = Random.Range(1, 9);

        // 10보다 크거나 같으면 랜덤을, 10보다 작으면 종료
        while ((num1 + num2) >= 10)
        {
            num1 = Random.Range(1, 9);
            num2 = Random.Range(1, 9);
        }
        sum = num1 + num2;

        // 수학 문제 Text 변경하기 
        nonParticle = (num2 == 0 || num2 == 1 || num2 == 3 || num2 == 6 || num2 == 7 || num2 == 8) ? "은" : "는";
        objParticle = (sum == 0 || sum == 1 || sum == 3 || sum == 6 || sum == 7 || sum == 8) ? "과" : "와";
        noticeText.text = $"{num1} 더하기 {num2}{nonParticle} {sum}{objParticle} 같습니다.";

        isExcute = true;
    }

    public int ReturnSum()
    {
        return sum;
    }

    public int ReturnNum1()
    {
        return num1;
    }

    public int ReturnNum2()
    {
        return num2;
    }
}

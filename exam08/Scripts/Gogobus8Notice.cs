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
    private string nonParticle; // �� ��
    private string objParticle; // �� ��

    private void Start()
    {
        CreateNotice();
    }

    // ���� ���� ������
    void CreateNotice()
    {
        // ���� �����ϱ�
        num1 = Random.Range(1, 9);
        num2 = Random.Range(1, 9);

        // 10���� ũ�ų� ������ ������, 10���� ������ ����
        while ((num1 + num2) >= 10)
        {
            num1 = Random.Range(1, 9);
            num2 = Random.Range(1, 9);
        }
        sum = num1 + num2;

        // ���� ���� Text �����ϱ� 
        nonParticle = (num2 == 0 || num2 == 1 || num2 == 3 || num2 == 6 || num2 == 7 || num2 == 8) ? "��" : "��";
        objParticle = (sum == 0 || sum == 1 || sum == 3 || sum == 6 || sum == 7 || sum == 8) ? "��" : "��";
        noticeText.text = $"{num1} ���ϱ� {num2}{nonParticle} {sum}{objParticle} �����ϴ�.";

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

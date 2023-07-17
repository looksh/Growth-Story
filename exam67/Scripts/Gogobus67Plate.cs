using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus67Plate : MonoBehaviour
{

    public List<GameObject> list = new();

    private int disappearCount;

    private void Start()
    {
        CreateGimbab();
    }

    void CreateGimbab()
    {
        disappearCount = Random.Range(1, 7); // ����� ��� ���� ���ϱ�

        for (int i = 0; i < disappearCount; i++)
        {
            list[i].SetActive(false);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus55Answer : MonoBehaviour
{
    public List<GameObject> objectList1 = new();
    public List<GameObject> objectList2 = new();

    private int rowIndex1;
    private int rowIndex2;

    private void Start()
    {
        DeleteShape();
    }

    // ����Ʈ�� �����ϴ� ������ ���� -> �����ϸ� shadow�� �巯��
    void DeleteShape()
    {
        // row1 ������ ���� ����
        rowIndex1 = Random.Range(0, objectList1.Count);
        objectList1[rowIndex1].SetActive(false);


        // row1�� �����۰� ��ġ�� �ʵ��� �ϴ� ����
        while (rowIndex1 != rowIndex2)
        {
            rowIndex2 = Random.Range(0, objectList2.Count);
        }
        objectList2[rowIndex2].SetActive(false);
    }
}

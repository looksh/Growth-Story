
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

    // 리스트에 존재하는 도형을 제거 -> 제거하면 shadow가 드러남
    void DeleteShape()
    {
        // row1 아이템 랜덤 제거
        rowIndex1 = Random.Range(0, objectList1.Count);
        objectList1[rowIndex1].SetActive(false);


        // row1의 아이템과 겹치지 않도록 하는 로직
        while (rowIndex1 != rowIndex2)
        {
            rowIndex2 = Random.Range(0, objectList2.Count);
        }
        objectList2[rowIndex2].SetActive(false);
    }
}

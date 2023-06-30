using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOrderChanger : MonoBehaviour
{
    public GameObject selectBoard;

    void Start()
    {
        // SelectBoard 오브젝트를 맨 위로 올림
        selectBoard.transform.SetAsFirstSibling();
    }
}

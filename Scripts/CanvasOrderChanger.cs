using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOrderChanger : MonoBehaviour
{
    public GameObject selectBoard;

    void Start()
    {
        // SelectBoard ������Ʈ�� �� �Ʒ��� �ø�
        selectBoard.transform.SetAsLastSibling();
    }
}

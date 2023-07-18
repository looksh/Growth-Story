using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus67Plate : MonoBehaviour
{

    public List<GameObject> list = new();
    public GameObject operation;
    public bool isExcute = false;

    private int DisappearCount;

    private void Start()
    {
        StartCoroutine(CreateGimbab());
        StartCoroutine(ShowOperation());
    }

    IEnumerator CreateGimbab()
    {
        yield return new WaitForSeconds(1f);
        DisappearCount = Random.Range(1, 10); // »ç¶óÁú ±è¹ä °³¼ö Á¤ÇÏ±â
        Debug.Log(DisappearCount);

        for (int i = 0; i < DisappearCount; i++)
        {
            Destroy(list[i]);
        }
        isExcute = true;
    }

    IEnumerator ShowOperation()
    {
        yield return new WaitForSeconds(2f);
        operation.SetActive(true);
    }

    public int ReturnDisappearCount()
    {
        return DisappearCount;
    }
}

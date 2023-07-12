using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gogobus55Image : MonoBehaviour
{
    public GameObject s;
    public GameObject t;
    public GameObject c;
    public GameObject r;
    public GameObject s2;
    public GameObject t2;
    public GameObject c2;
    public GameObject r2;

    public Sprite square;
    public Sprite circle;
    public Sprite rhombus;
    public Sprite triangle;

    public Gogobus55Answer answer;

    public void ChangeImg()
    {
        s.GetComponent<Image>().sprite = square;
        s2.GetComponent<Image>().sprite = square;
        t.GetComponent<Image>().sprite = triangle;
        t2.GetComponent<Image>().sprite = triangle;
        c.GetComponent<Image>().sprite = circle;
        c2.GetComponent<Image>().sprite = circle;
        r.GetComponent<Image>().sprite = rhombus;
        r2.GetComponent<Image>().sprite = rhombus;

        foreach (GameObject obj in answer.objectList1)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in answer.objectList2)
        {
            obj.SetActive(false);
        }
    }

    
}

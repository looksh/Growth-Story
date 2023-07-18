using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gogobus67ImageChanger : MonoBehaviour
{
    public GameObject img;
    public Gogobus67Plate plate;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite Nine;

    public void ImageChange()
    {
        switch (plate.ReturnDisappearCount())
        {
            case 1: img.GetComponent<Image>().sprite = one; break;
            case 2: img.GetComponent<Image>().sprite = two; break;
            case 3: img.GetComponent<Image>().sprite = three; break;
            case 4: img.GetComponent<Image>().sprite = four; break;
            case 5: img.GetComponent<Image>().sprite = five; break;
            case 6: img.GetComponent<Image>().sprite = six; break;
            case 7: img.GetComponent<Image>().sprite = seven; break;
            case 8: img.GetComponent<Image>().sprite= eight; break;
            case 9: img.GetComponent <Image>().sprite = Nine; break;
        }
    }
}

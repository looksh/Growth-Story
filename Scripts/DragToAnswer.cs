using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum InAndOut
{
    Fit, UnFit
}


public class DragToAnswer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public MathManager manager;
    public ValueManager valueManager;

    public static Vector2 startPos; // ���� ��ġ
    private Vector2 originPos; // �ʱ�ȭ ��ġ
    private Vector2 originSize; // ���� ũ��
    public float detectRange; // ���� ����
    public InAndOut inAndOut = InAndOut.UnFit;


    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // �亯 ī�� ��ġ �ʱ�ȭ
        originSize = GetComponent<RectTransform>().sizeDelta; // ���� ũ�� ����
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // ���� ��ġ �ʱ�ȭ

        GetComponent<RectTransform>().sizeDelta = originSize; // ���� ũ���

    }

    // �巡�� ��
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // ���� ��ġ
        this.transform.position = currentPos; // �亯 ī���� ��ġ�� ���� ��ġ�� ����
    }

    // �巡�� ����
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Transform objTransform = eventData.pointerEnter.transform;
        string objName = eventData.pointerEnter.name;
        
        int layerMask = 1 << 6; // 6�� ���̾�

        var hits = Physics.SphereCastAll(transform.position,
            detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                GameObject detect = hit.collider.gameObject;

                if (objName != "equal" && objName != "plus")
                {
                    if ((detect.name == "sumAnswer") || (detect.name != "equalAnswer" && detect.name != "plusAnswer"))
                    {
                        objTransform.position = new Vector3(detect.transform.position.x, detect.transform.position.y, detect.transform.position.z);
                        objTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                        inAndOut = InAndOut.Fit;

                        if (detect.name != "sumAnswer")
                        {
                            valueManager.ReceiveValue(eventData.pointerEnter.GetComponent<ValueManager>().value);
                            inAndOut = InAndOut.Fit;
                        }
                    }
                }
                else
                {
                    if ((detect.name == "equalAnswer" && objName == "equal") || (detect.name == "plusAnswer" && objName == "plus"))
                    {
                        objTransform.position = new Vector3(detect.transform.position.x, detect.transform.position.y, detect.transform.position.z);
                        objTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                        inAndOut = InAndOut.Fit;
                    }
                }
            }

            // ����. ��� selectCard�� ���°� Fit ���¿����Ѵ�.

            // sumAnswer �� ���� ����

            // sum �� ���� �ٸ��ٸ� ��� �ʱ�ȭ.




            if (GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut != InAndOut.UnFit)
            {
                if (GameObject.Find("sum").GetComponent<ValueManager>().value != valueManager.reserveValue)
                {
                    valueManager.reserveValue = 0;
                    Debug.Log("�ʱ�ȭ��: " + valueManager.reserveValue);

                    GetComponent<RectTransform>().position = originPos;
                    GetComponent<RectTransform>().sizeDelta = originSize; // ���� ũ���
                }
            }
        }
    }
}

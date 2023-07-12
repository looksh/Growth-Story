using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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

    public void Start()
    {
        originPos = GetComponent<RectTransform>().position; // �亯 ī�� ��ġ �ʱ�ȭ
        originSize = GetComponent<RectTransform>().sizeDelta; // ���� ũ�� ���� 
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Transform objTransform = eventData.pointerEnter.transform;

        startPos = this.transform.position; // ���� ��ġ �ʱ�ȭ
        GetComponent<RectTransform>().sizeDelta = originSize; // ���� ũ���

        if (objTransform.GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit)
        {
            valueManager.ReduceValue(eventData.pointerEnter.GetComponent<ValueManager>().value);
            inAndOut = InAndOut.UnFit;
        }
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
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);


        // ���콺�� ������ �� �ش� ��ü�� ���°� UnFit �����϶��� �ؿ� ��������� ����ϱ�
        if (objTransform.GetComponent<DragToAnswer>().inAndOut == InAndOut.UnFit)
        { 
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
                }
        }

        manager.MathResult();
    }
}

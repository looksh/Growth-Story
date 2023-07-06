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
    public GameObject resultText;
    public GameObject failedText;

    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 sumPos;
    private Vector2 plusPos;
    private Vector2 equalPos;

    private Vector2 firstSize;
    private Vector2 secondSize;
    private Vector2 sumSize;
    private Vector2 plusSize;
    private Vector2 equalSize;

    private void Awake()
    {
        firstPos = GameObject.Find("first").GetComponent<RectTransform>().position;
        secondPos = GameObject.Find("second").GetComponent<RectTransform>().position;
        sumPos = GameObject.Find("sum").GetComponent<RectTransform>().position;
        plusPos = GameObject.Find("plus").GetComponent<RectTransform>().position;
        equalPos = GameObject.Find("equal").GetComponent<RectTransform>().position;

        firstSize = GameObject.Find("first").GetComponent<RectTransform>().sizeDelta;
        secondSize = GameObject.Find("second").GetComponent<RectTransform>().sizeDelta;
        sumSize = GameObject.Find("sum").GetComponent<RectTransform>().sizeDelta;
        plusSize = GameObject.Find("plus").GetComponent<RectTransform>().sizeDelta;
        equalSize = GameObject.Find("equal").GetComponent<RectTransform>().sizeDelta;
    }

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
        inAndOut = InAndOut.UnFit;
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


        // ��� ��ü�� Fit���� �˻�
        if (GameObject.Find("first").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit 
            && GameObject.Find("second").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("plus").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit
            && GameObject.Find("equal").GetComponent<DragToAnswer>().inAndOut == InAndOut.Fit) 
        {
            // ���⼭ ������ �´��� �˻�
            if (GameObject.Find("sum").GetComponent<ValueManager>().value == valueManager.reserveValue)
            {
                // ����
                StartCoroutine(Result());
            }
            else
            {
                // ����
                valueManager.ResetValue();
                StartCoroutine(Failed());
                
            }
        }
    }

    void ResetTransform()
    {
        GameObject.Find("first").GetComponent<RectTransform>().position = firstPos;
        GameObject.Find("second").GetComponent<RectTransform>().position = secondPos;
        GameObject.Find("sum").GetComponent<RectTransform>().position = sumPos;
        GameObject.Find("plus").GetComponent<RectTransform>().position = plusPos;
        GameObject.Find("equal").GetComponent<RectTransform>().position = equalPos;

        GameObject.Find("first").GetComponent<RectTransform>().sizeDelta = firstSize;
        GameObject.Find("second").GetComponent<RectTransform>().sizeDelta = secondSize;
        GameObject.Find("sum").GetComponent<RectTransform>().sizeDelta = sumSize;
        GameObject.Find("plus").GetComponent<RectTransform>().sizeDelta = plusSize;
        GameObject.Find("equal").GetComponent<RectTransform>().sizeDelta = equalSize;

        GameObject.Find("first").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("second").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("sum").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("plus").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
        GameObject.Find("equal").GetComponent<DragToAnswer>().inAndOut = InAndOut.UnFit;
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(0.5f);
        resultText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MathOperation");
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(0.5f);
        failedText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ResetTransform();
        failedText.SetActive(false);
    }
}

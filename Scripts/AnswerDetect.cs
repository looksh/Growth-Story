using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerDetect : MonoBehaviour
{
    public float detectRange; // ���� ����
    public GameObject answerCard;
    public MathManager manager;
    public ValueManager valueManager;

    void Update()
    {
        //Detect();
    }

    // 1. �����Ǹ� ���� ī���� ���� ���޹��� �� �ֵ��� �ؾ��Ѵ�.
    // 2. ��� ���� ī�� ���� ���� �� �ֵ��� �������Ѵ�.

    public void Detect()
    {
        int layerMask = 1 << 6; // 6�� ���̾�

        var hits = Physics.SphereCastAll(transform.position,
            detectRange, Vector3.up, 0, layerMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                GameObject selectCard = hit.collider.gameObject;

                if (hit.collider.gameObject.name != "equal" && hit.collider.gameObject.name != "plus")
                {
                    // ������ ���� ī���� ���� ValueManager�� ����
                    valueManager.ReceiveValue(hit.collider.GetComponent<ValueManager>().value);
                    selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                }
                else
                {
                    //// equal �̸� equalAnswer �� �ٰ� plus �̸� plusAnswer�� �ٱ�
                    //switch (hit.collider.gameObject.name)
                    //{
                    //    case "equal":

                    //        {
                    //            selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    //            selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                    //            break;
                    //        }
                    //    case "plus":
                    //        {
                    //            selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
                    //            selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
                    //            break;
                    //        }
                    //}
                }
            }
        }

        //if (hits.Length > 0 )
        //{
        //    bool isSelectCardMatched = false; // selectCard.name�� ��ġ�ϴ��� ���θ� �����ϴ� ����
        //    foreach (var hit in hits)
        //    {
        //        if (hit.collider.gameObject.name == selectCard.name)
        //        {
        //            isSelectCardMatched = true;
        //            break;
        //        }
        //    }

        //    if (isSelectCardMatched)
        //    {
        //        // selectCard.name�� ��ġ�ϸ� ���� ī�� �̵� �� ũ�� ����
        //selectCard.transform.position = new Vector3(answerCard.transform.position.x, answerCard.transform.position.y, answerCard.transform.position.z);
        //selectCard.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 255);
        //    }
        //}
    }

    // ����� �׸��� �Լ�
    public void OnDrawGizmos()
    {
        // ���̾� ���Ǿ �׸���. (�׸���ġ, ������)
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gogobus55Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 startPos; // ���� ��ġ
    public float detectRange;
    public Gogobus55SuccessCount successObj;
    public Gogobus55Image img;
    public GameClearController gameClearController;
    private Vector2 originPos; // �ʱ�ȭ ��ġ
    private Vector2 originSize; // ���� ũ��
    
    void Start()
    {
        originPos = GetComponent<RectTransform>().position; // ���� ��ġ ����
        originSize = GetComponent<RectTransform>().sizeDelta; // ���� ũ�� ���� 
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position; // ���� ��ġ �ʱ�ȭ
    }

    // �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position; // ���� ��ġ
        this.transform.position = currentPos; // ���� ī���� ��ġ�� ���� ��ġ�� ����
    }

    // �巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        int layerMask = 1 << 6; // ���̾�6 �����ϱ�
        var hits = Physics.SphereCastAll(transform.position, detectRange, Vector3.up, 0, layerMask);

        Gogobus55State pointerState = eventData.pointerEnter.transform.GetComponent<Gogobus55State>();

        if (hits.Length > 0)
        {
            Gogobus55State detectState = hits[0].transform.GetComponent<Gogobus55State>();

            // �������� ���¿� ������ ��ü�� ���°� ���ٸ� ����ó��
            if (detectState.state == pointerState.state)
            {
                GetComponent<RectTransform>().position = new Vector3(hits[0].transform.position.x, hits[0].transform.position.y, hits[0].transform.position.z);
                successObj.IncreseCount();

                if (successObj.GetSuccessCount() == 2)
                {
                    img.ChangeImg();
                    StartCoroutine(SuccessGame());
                }
            }
            else
            {
                Debug.Log("����");
                GetComponent<RectTransform>().position = originPos;
            }
        }
    }

    IEnumerator SuccessGame()
    {
        yield return new WaitForSeconds(2.0f);
        gameClearController.UpdateClearCount();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gogobus55SuccessCount : MonoBehaviour
{
    private int successCount = 0;
    public GameClearController gameClearController;

    private void Awake()
    {
        // �̰� ���� �����ϸ� ������ �ѹ��� ������ ���� �������� �̵��ϸ� �۵��� �� �ϳ�
        Debug.Log("Gogobus55SuccessCount ����");
        StartCoroutine(GameManager());
    }

    IEnumerator GameManager()
    {
        yield return new WaitUntil(() => successCount == 2);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ȣ��");
        SuccessGame();
    }

    public void IncreseCount()
    {
        successCount++;
    }

    public int GetSuccessCount()
    {
        return successCount;
    }

    void SuccessGame()
    {
        gameClearController.UpdateClearCount();
    }
}

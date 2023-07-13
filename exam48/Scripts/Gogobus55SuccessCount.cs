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
        // 이게 지금 시작하면 세개가 한번에 켜져서 다음 게임으로 이동하면 작동을 안 하네
        Debug.Log("Gogobus55SuccessCount 시작");
        StartCoroutine(GameManager());
    }

    IEnumerator GameManager()
    {
        yield return new WaitUntil(() => successCount == 2);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("호출");
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

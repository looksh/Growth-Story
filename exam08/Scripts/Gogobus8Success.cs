using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus8Success : MonoBehaviour
{
    private int count = 0;
    public GameClearController gameClearController;

    private void Awake()
    {
        StartCoroutine(GameManager());
    }

    public int GetCount()
    {
        return count;
    }

    public void IncreaseCount()
    {
        count++;
    }

    void SuccessGame()
    {
        gameClearController.UpdateClearCount();
    }

    IEnumerator GameManager()
    {
        yield return new WaitUntil(() => count == 5);
        yield return new WaitForSeconds(0.5f);
        SuccessGame();
    }
}

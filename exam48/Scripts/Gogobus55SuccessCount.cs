using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogobus55SuccessCount : MonoBehaviour
{
    private int successCount = 0;

    public void IncreseCount()
    {
        successCount++;
    }

    public int GetSuccessCount()
    {
        return successCount;
    }
}

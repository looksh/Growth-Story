using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleChildren : MonoBehaviour
{
    public void Shuffle()
    {
        // Get all child objects of SelectBoard
        Transform selectBoard = transform;
        int childCount = selectBoard.childCount;
        List<Transform> children = new List<Transform>();

        for (int i = 0; i < childCount; i++)
        {
            children.Add(selectBoard.GetChild(i));
        }

        // Shuffle the children using Fisher-Yates algorithm
        for (int i = 0; i < childCount - 1; i++)
        {
            int randomIndex = Random.Range(i, childCount);
            Transform temp = children[i];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // Reorder the shuffled children
        for (int i = 0; i < childCount; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }
}

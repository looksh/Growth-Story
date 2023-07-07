using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WashingMachine : MonoBehaviour
{
    private Animator animator;
    public GameObject animObj;
    public LaundryBoard laundryBoard;

    private void Start()
    { 
        animator = GetComponent<Animator>();
    }

    // 클릭하면 문 열기
    public void OpenMachineDoor()
    {
        animator.SetTrigger("Open");
        StartCoroutine(laundryBoard.CreateLaundry());
        animObj.GetComponent<Button>().interactable = false;
    }

}

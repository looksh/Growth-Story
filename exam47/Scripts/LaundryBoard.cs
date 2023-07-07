using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryBoard : MonoBehaviour
{
    public List<GameObject> LaundryList; // ������ ������ ����Ʈ 
    private int NumberOfLaundry;

    // ���� ��� int
    public int GetRandomCountI()
    {
        return NumberOfLaundry;
    }

    // ���� ��� string
    public string GetRandomCountS()
    {
        return NumberOfLaundry.ToString();
    }

    // ������ �����ϱ�
    public IEnumerator CreateLaundry()
    {
        yield return new WaitForSeconds(1.5f);

        // ���� �����ϱ�
        NumberOfLaundry = Random.Range(0, 10);
        Debug.Log("���� ���� ��: " + NumberOfLaundry);

        // ������ ����ŭ �ݺ��ϱ� (�������� ����)
        // �� ���� �ݺ��� random ���� ������ ������ ����Ʈ���� �������� ���� �� ����.
        int random;
        for (int i = 0; i < NumberOfLaundry; i++)
        {
            random = Random.Range(0, LaundryList.Count);
            GameObject laundryObject = Instantiate(LaundryList[random]);
            laundryObject.transform.SetParent(transform);
        }
    }
}

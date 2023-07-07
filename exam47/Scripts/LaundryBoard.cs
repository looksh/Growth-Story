using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryBoard : MonoBehaviour
{
    public List<GameObject> LaundryList; // 빨랫감 프리팹 리스트 
    private int NumberOfLaundry;

    // 난수 얻기 int
    public int GetRandomCountI()
    {
        return NumberOfLaundry;
    }

    // 난수 얻기 string
    public string GetRandomCountS()
    {
        return NumberOfLaundry.ToString();
    }

    // 빨랫감 생성하기
    public IEnumerator CreateLaundry()
    {
        yield return new WaitForSeconds(1.5f);

        // 난수 생성하기
        NumberOfLaundry = Random.Range(0, 10);
        Debug.Log("난수 생성 값: " + NumberOfLaundry);

        // 난수의 값만큼 반복하기 (빨랫감의 개수)
        // 한 번에 반복에 random 값을 설정해 프리팹 리스트에서 무작위로 추출 후 생성.
        int random;
        for (int i = 0; i < NumberOfLaundry; i++)
        {
            random = Random.Range(0, LaundryList.Count);
            GameObject laundryObject = Instantiate(LaundryList[random]);
            laundryObject.transform.SetParent(transform);
        }
    }
}

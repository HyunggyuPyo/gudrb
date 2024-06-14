using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example0614 : MonoBehaviour
{
    SafeArray<int> safeArray;

    void Awake()
    {
        safeArray = new SafeArray<int>(30);
        Debug.Log("배열 생성");
    }

    void Start()
    {
        safeArray[0] = 1;
        print(safeArray[0]);
        safeArray[5] = 5;
        print(safeArray[5]);
        print(safeArray[31]);
    }
}

public class SafeArray<T>
{
    T[] slist;
    int size;

    public T this[int i] 
    {
        get 
        { 
            if(slist.Length < i)
            {
                Debug.Log("숫자가 배열의 크기를 벗어났어용");
                return default;
            }
            else
            {
                return slist[i];
            } 
        }
        set 
        { 
            if(slist.Length < i)
            {
                Debug.Log("숫자가 배열의 크기를 벗어났어용");
            }
            else
            {
                slist[i] = value;
            }
        } 
    }

    public SafeArray(int i)
    {
        slist = new T[i];
        size = i;
    }
}

//public T[] GetList()
//{
//    return slist;
//}

//public void SetList(int index, T value)
//{
//    if(size < index)
//    {
//        Debug.Log(" 배열의 크기를 벗어났습니다.");
//    }
//    else
//    {
//        slist[index] = value;
//    }
//}
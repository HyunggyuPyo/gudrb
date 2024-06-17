using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // Action 델리게이트 : 기본적인 형태의 델리게이트를 Dotnet에서 기본적으로 정의하여 제공 
    // ㄴ 반환형이 없는(void) Method 
    Action action;
    //Action 델리게이트에 제네릭 타입은 파라미터 타입을 지정
    Action<int> actionWithParam;
    Action<float, float> actionWithFloatPram; 
    
    // Func 델리게이트 : 반환형이 있는 형태의 델리게이트를 Dotnet에서 기본적으로 정의하여 제공.
    // ㄴ 무조건 리턴 타입을 정해줘야 사용 가능 = 제네릭 델리게이트
    Func<object> func;

    // Func 델리게이트는 제네릭 타입 중 맨 뒤는 반환형, 그 앞은 파라미터 타입 지정
    Func<string, int> parseFunc;

    //Predicate 델리게이트 : 반환형이 bool이고, 1개 이상의 파라미터가 있는 형태의 델리게이트
    Predicate<float> predicate;

    //Func<float, bool>로 사용하면 되지 Predicate는 왜 있느냐?

    private void Start()
    {
        action = SomeAction;
        actionWithParam = SomeActionWithPram;
        parseFunc = Parse;

        //Predicate 사용 이유  
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(7);
        intList.Add(8);
        intList.Add(9);

        //intList에서 짝수만 뽑아 사용하고 싶다 
        List<int> evenList = intList.FindAll(IsEven);
        foreach(int i in evenList)
        {
            print(i);
        }

        //짝수를 FindAll 할떄 무명 메서드를 사용할 경우 
        List<int> evenListByAnonymouysMethod = intList.FindAll(
            delegate (int param)
            {
                return param % 2 == 0;
            }
        );
    }
    // Predicate의 경우,일부 컬렉션 함수의 조건 판단을 위한 정의를 bool을 리턴하는 함수의 형태로 받기 위해 활용 됨.


    private void SomeAction() { }
    private void SomeActionWithPram(int a)
    {
        // 파라미터 A로 무언가 한다고 치고
    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    // 파라미터가 있고 bool값을 리턴함으로 Predicate가 맞다 
    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }
}

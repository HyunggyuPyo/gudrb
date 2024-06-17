using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // Action ��������Ʈ : �⺻���� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ���� 
    // �� ��ȯ���� ����(void) Method 
    Action action;
    //Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
    Action<int> actionWithParam;
    Action<float, float> actionWithFloatPram; 
    
    // Func ��������Ʈ : ��ȯ���� �ִ� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����.
    // �� ������ ���� Ÿ���� ������� ��� ���� = ���׸� ��������Ʈ
    Func<object> func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� �ڴ� ��ȯ��, �� ���� �Ķ���� Ÿ�� ����
    Func<string, int> parseFunc;

    //Predicate ��������Ʈ : ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ
    Predicate<float> predicate;

    //Func<float, bool>�� ����ϸ� ���� Predicate�� �� �ִ���?

    private void Start()
    {
        action = SomeAction;
        actionWithParam = SomeActionWithPram;
        parseFunc = Parse;

        //Predicate ��� ����  
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(7);
        intList.Add(8);
        intList.Add(9);

        //intList���� ¦���� �̾� ����ϰ� �ʹ� 
        List<int> evenList = intList.FindAll(IsEven);
        foreach(int i in evenList)
        {
            print(i);
        }

        //¦���� FindAll �ҋ� ���� �޼��带 ����� ��� 
        List<int> evenListByAnonymouysMethod = intList.FindAll(
            delegate (int param)
            {
                return param % 2 == 0;
            }
        );
    }
    // Predicate�� ���,�Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ� bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ�� ��.


    private void SomeAction() { }
    private void SomeActionWithPram(int a)
    {
        // �Ķ���� A�� ���� �Ѵٰ� ġ��
    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    // �Ķ���Ͱ� �ְ� bool���� ���������� Predicate�� �´� 
    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }
}

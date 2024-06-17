using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Delegate(�븮��)
 �� C++�� �Լ� �����Ϳ� ������ ���
 �� �޼��带 ����ó�� ���������� Ȱ���� �� �ִ� ���

���� -> ������ ���۷��� �ڷ��� ó�� ������ �����ϵ��� �����ؾ� �Ѵ�.

����: [���� ������] delegate [��ȯ��] delegateName ([�Ű����� ����]);

= ��������Ʈ�� ���� ��ġ�� class, enum�� ����
 */

public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);

public class DelegateTest : MonoBehaviour
{
    public float x;
    public float y;

    //public class InnerClass { } //�̳� Ŭ���� : Ŭ���� �ȿ� Ŭ����
    //public delegate float SomeDelegateMethod(float x, float y);

    //��������Ʈ �ʵ� ����
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divaide;
        //otherDelegate = PrintMessage;

        // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����
        // print�Լ��� �Ű����� Ÿ���� ������Ʈ�̰� ���� ������ �������̵�� ��Ʈ�������� �ٿ� ĳ������ ���� 
        otherDelegate = print;

        // Delegate�� �ν��Ͻ��� �����ϴ� �������� ������.
        otherDelegate = null;

        // �������� �ʱ�ȭ �ϴ¹� ������ ���ǻ� �����ϰ� 34~38�� �� ó�� �ۼ��Ͽ� ����Ѵ�.
        //otherDelegate = new OtherDelegateMethod(PrintMessage);

        //otherDelegate("");
        // ?.�� �����ϸ� ? ���� ������ null�ϰ�� ���� ���� ����.
        otherDelegate?.Invoke("");
        // ���� �ڵ�� if (otherDelegate != null) otherDelegate.Invoke(""); �� ����
        
    }

    public void CalcChange(int i)
    {
        switch(i)
        {
            case 0:
                someDelegate = plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divaide;
                break;
        }
    }

    public void ButtonClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float y)
    {
        return x - y;
    }

    public float Multiple(float a, float b)
    {
        return a * b;
    }

    public float Divaide(float i, float j)
    {
        return i / j;
    }

    // �� �Լ��� ���� ���� someDelegate�� ���� �� ����
    // �� ���� ���� ��������Ʈ�� �Ķ���Ͱ� �ΰ��� ���� Ÿ���� float�̱� ����
    // �� �� ��������Ʈ�� �Լ��� �������� �Ķ���Ϳ� ��ȯ Ÿ���� ���ƾ� �Ѵ�.
    public void PrintMessage(string message)
    {
        print(message);
    }
}

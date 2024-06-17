using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Delegate(대리자)
 ㄴ C++의 함수 포인터와 유사한 기능
 ㄴ 메서드를 변수처럼 가변적으로 활용할 수 있는 기능

정의 -> 일종의 레퍼런스 자료형 처럼 형식을 지정하도록 선언해야 한다.

선언: [접근 지정자] delegate [반환형] delegateName ([매개변수 지정]);

= 델리게이트의 선언 위치는 class, enum과 동일
 */

public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);

public class DelegateTest : MonoBehaviour
{
    public float x;
    public float y;

    //public class InnerClass { } //이너 클래스 : 클래스 안에 클래스
    //public delegate float SomeDelegateMethod(float x, float y);

    //델리게이트 필드 선언
    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divaide;
        //otherDelegate = PrintMessage;

        // 매개변수가 암시적 캐스팅이 가능한 경우에도 가능
        // print함수는 매개변수 타입이 오브젝트이고 내가 선언한 델리게이드는 스트링이지만 다운 캐스팅이 가능 
        otherDelegate = print;

        // Delegate도 인스턴스를 참조하는 형식으로 생성됨.
        otherDelegate = null;

        // 정석적인 초기화 하는법 하지만 편의상 생략하고 34~38번 줄 처럼 작성하여 사용한다.
        //otherDelegate = new OtherDelegateMethod(PrintMessage);

        //otherDelegate("");
        // ?.을 참조하면 ? 앞의 내용이 null일경우 참조 하지 않음.
        otherDelegate?.Invoke("");
        // 위에 코드는 if (otherDelegate != null) otherDelegate.Invoke(""); 와 같다
        
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

    // 이 함수는 내가 만든 someDelegate에 넣을 수 없음
    // ㄴ 내가 만든 델리게이트는 파라미터가 두개고 리턴 타입이 float이기 떄문
    // ㄴ 즉 델리게이트에 함수를 넣으려면 파라미터와 반환 타입이 값아야 한다.
    public void PrintMessage(string message)
    {
        print(message);
    }
}

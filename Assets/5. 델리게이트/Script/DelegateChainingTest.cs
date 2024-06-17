using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        otherDelegate = MessageTrim; // 델리게이트 인스턴스 생성, MessageTrim으로 초기화
        otherDelegate += MessageAllTrim; // 델리게이트 체인에 MessageAllTrim 추가
        otherDelegate += MessageDuplicate; // 델리게이트 체인에 MessageDuplicate 추가
        otherDelegate += MessageLower; // 델리게이트 체인에 MessageLower 추가

        otherDelegate -= MessageAllTrim; // 델리게이트 체인에 MessageAllTrim 제거
        // ㄴ 델리게이트 체인은 일종의 Stack구조, 같은 메소드 중에서만 선입 후출로 제거된다.

        otherDelegate?.Invoke("  Hello World  ");

        otherDelegate += MessageDuplicate; // 델리게이트 체인에 MessageDuplicate 추가
        otherDelegate += MessageDuplicate; // 델리게이트 체인에 MessageDuplicate 추가

        // 델리게이트 인스턴스를 새로 생성해서 대입 ( 위 에서 추가한 항목들 사라짐
        otherDelegate = MessageTrim;

        otherDelegate?.Invoke("  Hello World  ");

    }

    private void MessageTrim(string message)
    {
        // string.Trim() : 문자열에서 앞 뒤 공백을 제거하여 반환
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        //string.Replace()를 이용하여 문자열 내부의 공백까지 모두 제거
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        //string.ToLower() : 문자열의 영문자 대문자를 모두 소문자로 바꿔 반환
        print(message.ToLower());
    }



}

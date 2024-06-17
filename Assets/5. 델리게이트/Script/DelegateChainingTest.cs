using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        otherDelegate = MessageTrim; // ��������Ʈ �ν��Ͻ� ����, MessageTrim���� �ʱ�ȭ
        otherDelegate += MessageAllTrim; // ��������Ʈ ü�ο� MessageAllTrim �߰�
        otherDelegate += MessageDuplicate; // ��������Ʈ ü�ο� MessageDuplicate �߰�
        otherDelegate += MessageLower; // ��������Ʈ ü�ο� MessageLower �߰�

        otherDelegate -= MessageAllTrim; // ��������Ʈ ü�ο� MessageAllTrim ����
        // �� ��������Ʈ ü���� ������ Stack����, ���� �޼ҵ� �߿����� ���� ����� ���ŵȴ�.

        otherDelegate?.Invoke("  Hello World  ");

        otherDelegate += MessageDuplicate; // ��������Ʈ ü�ο� MessageDuplicate �߰�
        otherDelegate += MessageDuplicate; // ��������Ʈ ü�ο� MessageDuplicate �߰�

        // ��������Ʈ �ν��Ͻ��� ���� �����ؼ� ���� ( �� ���� �߰��� �׸�� �����
        otherDelegate = MessageTrim;

        otherDelegate?.Invoke("  Hello World  ");

    }

    private void MessageTrim(string message)
    {
        // string.Trim() : ���ڿ����� �� �� ������ �����Ͽ� ��ȯ
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        //string.Replace()�� �̿��Ͽ� ���ڿ� ������ ������� ��� ����
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        //string.ToLower() : ���ڿ��� ������ �빮�ڸ� ��� �ҹ��ڷ� �ٲ� ��ȯ
        print(message.ToLower());
    }



}

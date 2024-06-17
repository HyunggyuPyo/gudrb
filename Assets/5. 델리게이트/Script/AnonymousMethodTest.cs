using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonymousMethodTest : MonoBehaviour
{
    System.Action someAction;
    System.Action<int, float> autoCastPlus;
    System.Func<int, string> someFunc;
    System.Func<int, int, string> someFunc2;

    //����޼���� 
    //Ŭ���� ���� �ƴ� �޼��� ������ ���ǵǴ� �޼��� 
    // �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ��� 
    // �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.

    // ���� �޼����� ���� : 1ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ���� �������� �����Ѵ�.
    // ���� ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���� ��� �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ���
    // ���� �ϹǷ� ���ʿ��ϰ� �Լ��� �޸𸮸� �����ϴ°��� ������ �� �ִ�.
    // ���� �޼����� ���� : ��������Ʈ ü�̴��� ����Ҷ�, �ش� �޼��常 ü�ο��� �����ϴ°��� �Ұ����ϴ�.
    // ����, �� �޼��忡�� ���� ����޼��� ���� �ÿ� ������ �������� ������ �� �ִ�.

    // ���ٽ� : ����޼����� ���� ǥ��

    private void Awake()
    {
        someAction = delegate () // �Լ��� �̸��� ���� ���� �ż���� �θ���.
        {
            print("Anonymous Method Called.");
        };

        // �̷��� �غ��� ���� �ż���� ü�̴׿��� ���� �� �� ����
        someAction -= delegate () 
        {
            print("Anonymous Method Called.");
        };

        autoCastPlus = delegate (int a, float b)
        {
            int result = a = (int)b;
            print(result);
        };
        // ���� �޼��� �Ҵ翡�� �Ű����� ������ ���ʿ��� ��� ������ �����ϴ�.
        autoCastPlus = delegate (int a, float b)
        {
            print("Calc Finished!");
        };

        someFunc = delegate (int a)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("�Էµ� �Ķ���ʹ� ");
            sb.Append(a);
            sb.Append("�Դϴ�.");

            return sb.ToString();
        };

        //���ٽ� ǥ�� ���
        someAction += (/*�Ķ����*/) => { /*�Լ� ����*/ };

        //delegate Ű���� ��� => ��ȣ�� ���� ����޼��� ���� ���.
        someFunc += (int a) => { return a + "is intager."; };

        // �Ű������� �ڷ���(�Ķ���Ͱ� �Ѱ��� ��� ��ȣ��)�� returnŰ���� ���� ����
        someFunc += a => a + "is intager.";
        // �Ű������� 2�� �̻��� ��� �ݵ�� ��ȣ �ȿ� �Ű��������� ����
        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";

    }

    private void Start()
    {
        someAction?.Invoke();
        someAction?.Invoke();
        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc?.Invoke(1));
    }

    private void SomeAction()
    {

    }
}

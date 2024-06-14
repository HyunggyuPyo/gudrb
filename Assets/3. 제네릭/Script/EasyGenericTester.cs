using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EasyGenericTester : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    private void Awake()
    {
        //cubeFrom�� colors, xPositions, scales �迭�� ���� �����ϰ� ����.
        cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
        cubeTo.xPositions = ArrayCopy<int>(cubeFrom.xPositions);
    }

    //private Color[] ArrayCopy(Color[] from)
    //{
    //    Color[] to = new Color[from.Length];

    //    for(int i=0; i < from.Length; i++)
    //    {
    //        to[i] = from[i];
    //    }

    //    return to;
    //}

    // ���� �ڵ带 �� �������� �����ؼ� ����� ��û�� ���� �����ϱ� ���� ���׸� ����� �Ʒ� �Լ�
    private T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];

        for (int i = 0; i < from.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }
}

/*
 
���׸� Ȱ���� ũ�� �ΰ���

1. ���׸��� ����Ͽ� ���ǵ� Ŭ������ �ڷ������� ��� �Ǵ� �Լ��� ȣ��
 �� List<int> : List��� Ŭ������ ����ϴµ�, �ȿ��� ��޵� �ڷ����� int
 �� GetComponent<T>() : ���� ������Ʈ�� ������ ������Ʈ�� ã�µ�, T Ŭ������ ������Ʈ�� ã�´�.

2. ���� ���׸��� ����� Ŭ���� �Ǵ� �Լ��� ���� 

*/

public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>();
    public Dictionary<int, int> intDic = new Dictionary<int, int>();

    private void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

        StructT<Vector3> a;
        ClassT<GameObject> b;
        NewT<object> c;
        ParentT<Child> d;
        InterfaceT<string> e;
    }

}

//Ŭ�������� ����ϴ� ���׸� �ڷ����� ��������� ����� �� �ִ�.

//T�� ������ struct���� �Ѵ�.
class StructT<T> where T : struct { } // ����ü�� �����ϰ� �� ���

class ClassT<T> where T : class { } // Ŭ������ �����ϰ�

class NewT<T> where T : new() { } // �Ķ���Ͱ� ���� �⺻ �����ڸ� ������ Ŭ������ ����

class ParentT<T> where T : Parent { } // Parent Ŭ������ ����� Ŭ������ �����ϰ�


class InterfaceT<T> where T : IComparable { } // IComparable �������̽��� ������ Ŭ������ �����ϰ�

class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { } // ���׸��� ������ ����ϰ� ���� ���

class NoneDefaultConstructotClass
{
    public NoneDefaultConstructotClass(int a)
    {

    }
}

class Parent
{

}

class Child : Parent
{ }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyGeneric<SomeType> where SomeType : class, ICloneable
{
    private SomeType someVal;

    public MyGeneric(SomeType someVal)
    {
        this.someVal = someVal;
    }
        

    public SomeType GetSome()
    {
        return someVal;
    }

    public SomeType GetClone()
    {
        return someVal.Clone() as SomeType;
    }
}

public class GenericTest : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;

    public Action<int, int, float> someAction;

    public Func<int, int, float> someFunc;

    public void SomeAction(int a, int b, float c)
    {

    }

    public float SomeFunc(int a, int b)
    {
        return default;
    }

    private void Start()
    {
        someAction = SomeAction;
        someFunc = SomeFunc;

        Renderer sphere1Renderer = sphere1.GetComponent<Renderer>();
        Renderer sphere2Renderer = sphere2.GetComponent<Renderer>();
        sphere1Renderer.material.color = Color.red;
        sphere2Renderer.material.color = Color.blue;

        //새 Sphere 생성
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newSphere";

        newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);

        //함수에서 ganeric을 사용할 경우, 반환 자요형을 가변적으로 받을 수 있다.
        newSphere.GetComponent<Renderer>().material.color = GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);

        ////함수에서 generic을 쓰지 않을 경우 
        //newSphere.GetComponent(typeof(Renderer)) as Renderer).material.color = GgetMiddle<Color>(sphere1Renderer;

        //MyGeneric<int> myIntGeneric = new MyGeneric<int>(1);

        //print(myIntGeneric.GetSome());

        MyGeneric<string> myStringGeneric = new MyGeneric<string>("a");

        print(myStringGeneric.GetSome());

        //MyGeneric<GameObject> myGOGeneri = new MyGeneric<GameObject>(new GameObject());

        //myGOGeneri.GetSome().name = "MyGameObjectGeneric";

        //새 구체의 위치를 구베1과 구체2의 사이에 두고싶음
        //새 구체의 색을 구체1과 구체2의 rgb 값을 딱 중간 값으로 설정하고 싶음
    }

    //위치의 중간값을 구하는 함수 
    private Vector3 GetMiddle(Vector3 a, Vector3 b)
    {
        Vector3 @return = new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);

        return @return;
    }

    //색의 중간값을 구하는 함수
    private Color GetMiddle(Color a, Color b)
    {
        Color @return = new Color((a.r + b.r) / 2, (a.g + b.g) / 2, (a.b + b.b) / 2);

        return @return;
    }

    private T GetMiddle<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        dynamic c = (da + db) / 2;

        return (T)c;
    }
}


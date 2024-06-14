using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectionTest : MonoBehaviour
{
    /*
    오늘 수업내용 (컬렉션)
    데이터를 묶을 단위로 취급할 수있는 클래스의 집합
    1. 배열
    2. 리스트 (어레이리스트)
    3. 딕셔너리(해쉬테이블)
    4.스택 / 큐

    정수형 배열을 선언한다.
     ㄴ int[] intArray; (자료형[] 배열이름)
    */

    #region 배열

    private int[] intArray = new int[5];
    //private int[] intArray;
    // 기본적으로 배열은 래퍼런스 타입이기 떄문에 초기화 할당을 하지 않으면 null 상태
    private int someInt;
    // 리터럴 타입은 초기값 할당을 하지 않아도 기본값이 할당된다.
    public int[] publicIntArray = new int[10];

    #endregion

    //private void Reset()
    //{
    //    //Reset함수 : 유니티 인스펙터에서 Reset시 호출 되는 함수
    //    //전역 변수의 초기값 할당 수행 후, 호출 됨
    //    publicIntArray = new int[15];
    //}
    #region 리스트

    //배열과 비슷한 기능을 한다.
    //유동적으로 크기 변경이 가능하다
    //요서 비교 등의 기능을 지워하는 함수가 포함된 클래스

    private List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    public ArrayList publicArrayList;

    #endregion

    #region 딕셔너리

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // 딕셔너리는 public을 사용해도 인스펙터에서는 사용이 불가능하다.
    // 하지만 시간 복잡도가 낮으니 대량의 데이터를 다룰때 사용하니 잘 알아두자
    public Dictionary<string, GameObject> publicDictionary;

    // 배열: 공간복잡도가 낮은 대신에 시간 복잡도가 높은 자료형
    // 딕셔너리(해시테이블): 키를 매칭하므로 공간 복잡도는 높고(키와 값 두개의 배열을 사용하기 때문) 시간 복잡도는 낮다(0번째 값부터 검사하지 않기 떄문). 

    //해쉬테이블 잘 사용은 하지 않지만 기본 배열이니 알아두자 여기서 파생된게 딕셔너리
    private Hashtable hastable = new Hashtable();

    #endregion

    #region 스택, 큐

    //스택
    private Stack<int> intStack = new Stack<int>();

    //큐
    private Queue<int> intQueue = new Queue<int>();    

    #endregion

    //프로퍼티 
    // 1.
    private int a;

    public int A { get { return a; } set { a = value; } }

    //2.
    private int a_1;

    public void SetA_1(int value)
    {
        a_1 = value;
    }
    public int GetA_1()
    {
        return a_1;
    }


    private void Start()
    {
        //intArray[0] = 1;
        //intArray[1] = 1;
        //intArray[2] = 1;
        //intArray[3] = 1;
        //intArray[4] = 1;

        //System.Array.Fill<int>(intArray, 1);



        ////1.for 방식
        ////for(int i=0; i< intArray.Length; i++)
        ////{
        ////    print(intArray[i]);
        ////}

        ////2.foreach 방식
        //foreach (int someInt in intArray)
        //{
        //    print(someInt);
        //}

        //intList.Add(1);
        //intList.Add(2);
        //intList.Add(3);
        //intList.Add(4);
        //intList.Add(5);

        ////foreach  (int someInt in intList)
        ////{
        ////    print(someInt);
        ////}

        //print(intList[4]);

        //foreach(GameObject obj in gameObjects)
        //{
        //    print(obj.name);
        //}

        ////arrayList는 List와 같은 형태로 활용 할 수 있지만
        ////데이터의 자료형을 제한하지 않으며, 기본적으로 Boxing되어 할당됨

        //arrayList.Add(1);
        //arrayList.Add(1f);
        //arrayList.Add(new GameObject("내가 만든 객체"));
        //arrayList.Add(new ArrayList());

        //foreach(object element in arrayList)
        //{
        //    print(element);
        //}

        //               //언박싱
        //print((arrayList[2] as GameObject).name);

        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);

        //리스트 참조
        //print(intList[0]);

        //딕셔너리 참조
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.magenta;
        dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.yellow;
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.black;

        hastable.Add("a", 1);
        hastable.Add(3f, new GameObject());

        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        print(intStack.Pop()); //1
        print(intStack.Pop());//2
        print(intStack.Pop());//3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop());//7
        print(intStack.Pop());//6
        print(intStack.Pop());//4
        print(intStack.Pop());//5

        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
        print(intQueue.Dequeue());

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue());
        print(intQueue.Dequeue());
    }
}

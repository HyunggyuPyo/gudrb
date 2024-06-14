using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectionTest : MonoBehaviour
{
    /*
    ���� �������� (�÷���)
    �����͸� ���� ������ ����� ���ִ� Ŭ������ ����
    1. �迭
    2. ����Ʈ (��̸���Ʈ)
    3. ��ųʸ�(�ؽ����̺�)
    4.���� / ť

    ������ �迭�� �����Ѵ�.
     �� int[] intArray; (�ڷ���[] �迭�̸�)
    */

    #region �迭

    private int[] intArray = new int[5];
    //private int[] intArray;
    // �⺻������ �迭�� ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ null ����
    private int someInt;
    // ���ͷ� Ÿ���� �ʱⰪ �Ҵ��� ���� �ʾƵ� �⺻���� �Ҵ�ȴ�.
    public int[] publicIntArray = new int[10];

    #endregion

    //private void Reset()
    //{
    //    //Reset�Լ� : ����Ƽ �ν����Ϳ��� Reset�� ȣ�� �Ǵ� �Լ�
    //    //���� ������ �ʱⰪ �Ҵ� ���� ��, ȣ�� ��
    //    publicIntArray = new int[15];
    //}
    #region ����Ʈ

    //�迭�� ����� ����� �Ѵ�.
    //���������� ũ�� ������ �����ϴ�
    //�伭 �� ���� ����� �����ϴ� �Լ��� ���Ե� Ŭ����

    private List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    public ArrayList publicArrayList;

    #endregion

    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // ��ųʸ��� public�� ����ص� �ν����Ϳ����� ����� �Ұ����ϴ�.
    // ������ �ð� ���⵵�� ������ �뷮�� �����͸� �ٷ궧 ����ϴ� �� �˾Ƶ���
    public Dictionary<string, GameObject> publicDictionary;

    // �迭: �������⵵�� ���� ��ſ� �ð� ���⵵�� ���� �ڷ���
    // ��ųʸ�(�ؽ����̺�): Ű�� ��Ī�ϹǷ� ���� ���⵵�� ����(Ű�� �� �ΰ��� �迭�� ����ϱ� ����) �ð� ���⵵�� ����(0��° ������ �˻����� �ʱ� ����). 

    //�ؽ����̺� �� ����� ���� ������ �⺻ �迭�̴� �˾Ƶ��� ���⼭ �Ļ��Ȱ� ��ųʸ�
    private Hashtable hastable = new Hashtable();

    #endregion

    #region ����, ť

    //����
    private Stack<int> intStack = new Stack<int>();

    //ť
    private Queue<int> intQueue = new Queue<int>();    

    #endregion

    //������Ƽ 
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



        ////1.for ���
        ////for(int i=0; i< intArray.Length; i++)
        ////{
        ////    print(intArray[i]);
        ////}

        ////2.foreach ���
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

        ////arrayList�� List�� ���� ���·� Ȱ�� �� �� ������
        ////�������� �ڷ����� �������� ������, �⺻������ Boxing�Ǿ� �Ҵ��

        //arrayList.Add(1);
        //arrayList.Add(1f);
        //arrayList.Add(new GameObject("���� ���� ��ü"));
        //arrayList.Add(new ArrayList());

        //foreach(object element in arrayList)
        //{
        //    print(element);
        //}

        //               //��ڽ�
        //print((arrayList[2] as GameObject).name);

        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);

        //����Ʈ ����
        //print(intList[0]);

        //��ųʸ� ����
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

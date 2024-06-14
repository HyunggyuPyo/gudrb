using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if EXAMPLE1
public class Extra0612 : MonoBehaviour
{
    Queue<Vector3> cubeQueueVector = new Queue<Vector3>();
    Queue<Color> cubeQueueColor = new Queue<Color>();
    Vector3 randPos;

    void Start()
    {
        StartCoroutine(RandCube());
    }

    IEnumerator RandCube()
    {
        while(true)
        {
            if (cubeQueueVector.Count != 0)
            {
                gameObject.transform.position = cubeQueueVector.Peek();
                gameObject.GetComponent<Renderer>().material.color = cubeQueueColor.Peek();
                cubeQueueVector.Dequeue();
                cubeQueueColor.Dequeue();

                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }
    }
    public void RedBtn()
    {
        cubeQueueColor.Enqueue(Color.red);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        cubeQueueVector.Enqueue(randPos);
    }
    public void BlueBtn()
    {
        cubeQueueColor.Enqueue(Color.blue);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        cubeQueueVector.Enqueue(randPos);
    }
    public void GreenBtn()
    {
        cubeQueueColor.Enqueue(Color.green);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        cubeQueueVector.Enqueue(randPos);
    }   
}
#endif

#if EXAMPLE2

public class Extra0612 : MonoBehaviour
{
Stack<Vector3> CapsuleStackVector = new Stack<Vector3>();
    Stack<Color> CapsuleStackColor = new Stack<Color>();

    Stack<Vector3> CapsuleVector = new Stack<Vector3>();
    Stack<Color> CapsuleColor = new Stack<Color>();

    Vector3 randPos;
    

    void Start()
    {
        StartCoroutine(RandCube());
    }

    IEnumerator RandCube()
    {
        while (true)
        {
            ArrayChange();

            if (CapsuleVector.Count != 0)
            {
                gameObject.transform.position = CapsuleVector.Pop();
                gameObject.GetComponent<Renderer>().material.color = CapsuleColor.Pop();

                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    void ArrayChange()
    {
        for(int i =0; i < CapsuleStackVector.Count; i++)
        {
            CapsuleVector.Push(CapsuleStackVector.Pop());
            CapsuleColor.Push(CapsuleStackColor.Pop());
        }
    }

    public void RedBtn()
    {
        CapsuleStackColor.Push(Color.red);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        CapsuleStackVector.Push(randPos);
    }
    public void BlueBtn()
    {
        CapsuleStackColor.Push(Color.blue);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        CapsuleStackVector.Push(randPos);
    }
    public void GreenBtn()
    {
        CapsuleStackColor.Push(Color.green);
        randPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        CapsuleStackVector.Push(randPos);
    }

}
#endif
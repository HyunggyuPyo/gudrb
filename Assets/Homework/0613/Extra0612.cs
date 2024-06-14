using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0612 : MonoBehaviour
{
    List<Vector3> vectorList = new List<Vector3>();
    List<Color> colorList = new List<Color>();

    private void Start()
    {
        RandomVector();
        RandomColor();

        StartCoroutine(RandomSphere());
    }

    IEnumerator RandomSphere()
    {
        while(true)
        {
            gameObject.transform.position = vectorList[Random.Range(0, 5)];
            gameObject.GetComponent<Renderer>().material.color = colorList[Random.Range(0, 5)];

            yield return new WaitForSeconds(1f);
        }
    }


    void RandomVector()
    {
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(-10, 11);
            int y = Random.Range(-10, 11);
            int z = Random.Range(-10, 11);

            vectorList.Add(new Vector3(x, y, z));
        }
    }

    void RandomColor()
    {
        for (int i = 0; i < 5; i++)
        {
            colorList.Add(new Color(Random.value, Random.value, Random.value));
        }
    }
}

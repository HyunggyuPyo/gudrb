using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTester : MonoBehaviour
{
    private ObjectPool pool;

    private void Awake()
    {
        if(pool == null)
        {
            pool = GetComponent<ObjectPool>();
        }
    }

    // 버튼에서 호출할 public 함수
    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();
                               // vecter3로 반환되는 프로퍼티, xyz값이 모두 -1~1사이
        obj.transform.position = Random.insideUnitSphere * 5;
        StartCoroutine(DespawnCoroutine(obj));
    }

    // 2~5초 후에 오브젝트를 풀에 되돌려주는 코루틴
    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        pool.ReturnObject(obj);
    }
}

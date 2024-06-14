using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    //public abstract class Monster : MonoBehaviour, IHitable
    //abstract 키워드 붙이면 오브젝트에 컴포넌트로 넣어서 사용 불가 / 상속으로만 가능

    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;

    public GameObject bulletPrefabs;
    public Transform shotPoint;

    public float shotIntrval = 1f;

    void Start()
    {
        StartCoroutine(ShotCoroutine());
    }

    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        //Debug.Log()랑 print()랑 같음
        print($"{name} Take Damge : {damage}, current HP : {currentHP}");
    }

    IEnumerator ShotCoroutine()
    {
        if(bulletPrefabs == null || shotPoint == null)
        {
            yield break;
        }

        while(true)
        {
            Shot();

            yield return new WaitForSeconds(shotIntrval);
        }
    }

    public void Shot()
    {
        // bullet 생성
        GameObject bulletObject = Instantiate(bulletPrefabs, shotPoint.position, shotPoint.rotation);

        //rigidbody 참조 및 Addforce를 통해 앞으로 날아감
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        //Bullet 참조 및 데미지 할당
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");

        // 3초후에 없어짐
        Destroy(bulletObject, 3f);
    }
}

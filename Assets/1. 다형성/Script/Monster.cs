using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    //public abstract class Monster : MonoBehaviour, IHitable
    //abstract Ű���� ���̸� ������Ʈ�� ������Ʈ�� �־ ��� �Ұ� / ������θ� ����

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
        //Debug.Log()�� print()�� ����
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
        // bullet ����
        GameObject bulletObject = Instantiate(bulletPrefabs, shotPoint.position, shotPoint.rotation);

        //rigidbody ���� �� Addforce�� ���� ������ ���ư�
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        //Bullet ���� �� ������ �Ҵ�
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");

        // 3���Ŀ� ������
        Destroy(bulletObject, 3f);
    }
}

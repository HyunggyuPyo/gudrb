using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    public Bullet bulletPrefab;
    public Transform shotPoint;

    public float damage = 10;

    public float maxHP = 100;
    public float currentHP = 100;

    public void Hit(float damage)
    {
        currentHP -= damage;
        print($"Player Take Damage  : {damage}, current hp : {currentHP}");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Shot()
    {
        //Debug.Log($"{gameObject.name} press button");

        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);

        bullet.damage = damage;

        //bullet에게 맞아야 할 대상의 Layer를 지정
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));

        Destroy(bullet, 3f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public Transform[] hands;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] WeaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon)
    {
        if (index > weapons.Length)
            return;

        weapons[index] = weapon;

        // 착용하고 있던 아이템이 있다면
        if (WeaponObjs[index] != null)
        {
            Destroy(WeaponObjs[index]);
            WeaponObjs[index] = null;
        }

        // 매개변수 weapon이 null이 아니면 
        if(weapon != null) // 무기 오브젝트 생성
        {
            //var someWeapon = Instantiate(weapon.equipPrefab);
            //someWeapon.transform.SetParent(hands[index]);
            //someWeapon.transform.localPosition = Vector3.zero;
            // 이렇게 세줄 쓸거면 아래로 한 줄 

            WeaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }

    }
}

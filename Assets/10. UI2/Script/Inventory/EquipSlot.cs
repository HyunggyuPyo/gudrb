using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySlot
{

    //public class a
    //{
    //    public virtual void DoA()
    //    {
    //        Debug.Log("Do A");
    //    }
    //}

    //public class b : a
    //{
    //    public override void DoA()
    //    {
    //        Debug.Log("Actually Do B");
    //    }
    //}

    public Image defaultIconImage; // �������� ���� �� ������ ������ ������
    public PlayerEquip playerEquip;
    public int handIndex;

    //set item�� �Ҷ� 
    //item propertie�� ���� �����Ҷ��� ������ ����

    //private void Start()
    //{
    //    a a = new b();

    //    a.DoA();
    //}

    public override Item Item 
    { 
        get => base.Item;
        set 
        {
            if(value is Weapon)
            {
                // �������� �������� �����
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;
                base.Item = value;
            }
            else if(value == null) 
            {
                // ���⸦ �����Ͽ� �� �� null�� ����.
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        } 
    }

    public override bool TrySwap(Item item)
    {
        if(item is Weapon || item == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

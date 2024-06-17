using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Example0617 : MonoBehaviour
{
    public static Example0617 Instance { get; set; }

    //public Transform invenPanel;
    List<GameObject> inven;
    public Color wcolor;

    private void Awake()
    {
        Instance = this;
        inven = new List<GameObject>();
        InvenImage();
    }
    
    public void WeaponButtonClick()
    {
        ColorBack();
        List<GameObject> evenList = inven.FindAll(IsWeapon);
        foreach (GameObject obj in evenList)
        {
            Color itemColor = obj.GetComponent<SpriteRenderer>().color;
            itemColor.a = 0.5f;
            obj.GetComponent<SpriteRenderer>().color = itemColor;
            print($"현재 {obj.name}의 색은 {itemColor}입니다.");
            InvenImage();
        }
    }

    public void EquipmentButtonClick()
    {
        ColorBack();
        List<GameObject> evenList = inven.FindAll(IsEquipment);
        foreach (GameObject obj in evenList)
        {
            Color itemColor = obj.GetComponent<SpriteRenderer>().color;
            itemColor.a = 0.5f;
            obj.GetComponent<SpriteRenderer>().color = itemColor;
            print($"현재 {obj.name}의 색은 {itemColor}입니다.");
            InvenImage();
        }
    }

    public void ExpendablesButtonClick()
    {
        ColorBack();
        List<GameObject> evenList = inven.FindAll(IsExpendables);
        foreach (GameObject obj in evenList)
        {
            Color itemColor = obj.GetComponent<SpriteRenderer>().color;
            itemColor.a = 0.5f;
            obj.GetComponent<SpriteRenderer>().color = itemColor;
            print($"현재 {obj.name}의 색은 {itemColor}입니다.");
            InvenImage();
        }
    }

    public void EtcButtonClick()
    {
        ColorBack();
        List<GameObject> evenList = inven.FindAll(IsEtc);
        foreach (GameObject obj in evenList)
        {
            Color itemColor = obj.GetComponent<SpriteRenderer>().color;
            itemColor.a = 0.5f;
            obj.GetComponent<SpriteRenderer>().color = itemColor;
            print($"현재 {obj.name}의 색은 {itemColor}입니다.");
            InvenImage();
        }
    }

    private bool IsWeapon(GameObject obj)
    {
        return obj.GetComponent<ItemInfo0617>().classification[0] != "무기" && obj.GetComponent<ItemInfo0617>().classification[1] != "무기";
    }
    private bool IsEquipment(GameObject obj)
    {
        return obj.GetComponent<ItemInfo0617>().classification[0] != "장비" && obj.GetComponent<ItemInfo0617>().classification[1] != "장비";
    }
    private bool IsExpendables(GameObject obj)
    {
        return obj.GetComponent<ItemInfo0617>().classification[0] != "소모품" && obj.GetComponent<ItemInfo0617>().classification[1] != "소모품";
    }
    private bool IsEtc(GameObject obj)
    {
        return obj.GetComponent<ItemInfo0617>().classification[0] != "기타" && obj.GetComponent<ItemInfo0617>().classification[1] != "기타";
    }

    public void InvenImage()
    {
        for (int i = 0; i < inven.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Image>().sprite = inven[i].GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(i).gameObject.GetComponent<Image>().color = inven[i].GetComponent<SpriteRenderer>().color;
            
        }
    }

    private void ColorBack()
    {
        for (int i = 0; i < inven.Count; i++)
        {
            wcolor.a = 1f;
            inven[i].GetComponent<SpriteRenderer>().color = wcolor;
        }
    }

    public void GetItem(GameObject obj)
    {
        inven.Add(obj);
    }    
}

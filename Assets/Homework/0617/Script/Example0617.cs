using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example0617 : MonoBehaviour
{
    public static Example0617 Instance { get; set; }

    //public Transform invenPanel;
    List<GameObject> inven;

    private void Awake()
    {
        Instance = this;
        inven = new List<GameObject>();
        InvenImage();
    }

    public void WeaponButtonClick()
    {
        for (int i = 0; i < inven.Count; i++)
        {
            if(inven[i].GetComponent<ItemInfo0617>().classification[0] != "무기" || inven[i].GetComponent<ItemInfo0617>().classification[0] != "무기")
            {
                Color itemColor;
                itemColor = transform.GetChild(i).gameObject.GetComponent<Image>().color;
                itemColor.a = 0.5f;
            }
        }
    }

    public void InvenImage()
    {
        for (int i = 0; i < inven.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Image>().sprite = inven[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void GetItem(GameObject obj)
    {
        inven.Add(obj);
    }    
}

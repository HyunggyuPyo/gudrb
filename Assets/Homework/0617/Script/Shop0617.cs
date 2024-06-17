using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop0617 : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;

    public void GetArrowItemButtonClick()
    {
        Example0617.Instance.GetItem(items[0]);
        Example0617.Instance.InvenImage();
    }
    public void GetAxeItemButtonClick()
    {
        Example0617.Instance.GetItem(items[1]);
        Example0617.Instance.InvenImage();
    }
    public void GetBackItemButtonClick()
    {
        Example0617.Instance.GetItem(items[2]);
        Example0617.Instance.InvenImage();
    }
    public void GetLootItemButtonClick()
    {
        Example0617.Instance.GetItem(items[3]);
        Example0617.Instance.InvenImage();
    }
}

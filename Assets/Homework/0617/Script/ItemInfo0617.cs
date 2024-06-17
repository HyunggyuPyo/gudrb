using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo0617 : MonoBehaviour
{
    [HideInInspector]
    public Sprite imgSprite;
    public string[] classification;

    void Awake()
    {
        imgSprite = GetComponent<SpriteRenderer>().sprite;
    }
}

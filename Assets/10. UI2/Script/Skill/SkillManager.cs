using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    public RectTransform skillPage;
    public RectTransform invenContent;

    public 

    public List<Skill> tempSkill;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        tempSkill.InsertRange(0, tempSkill);

        for(int i = 0; i < tempSkill.Count; i++)
        {
            //invenContent.GetChild(i).GetComponent<>
        }
    }
}

[System.Serializable]
public class Skill
{
    public Sprite iconSprite;
    public string name;
    public string desc;
    public float damage;
}

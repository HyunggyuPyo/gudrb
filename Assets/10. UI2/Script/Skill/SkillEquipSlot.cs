using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipSlot : SkillInventorySlot
{
    public Image defaultIconImage;
    public PlayerSkill playerSkill;
    public Image coolTimeImage;
    private SkillCooltime skillCooltime;
    public int equipIndex;

    void Awake()
    {
        skillCooltime = GetComponentInChildren<SkillCooltime>();
        //skillCooltime = FindObjectOfType<SkillCooltime>();
    }

    public override Skill Skill
    {
        get => base.Skill;
        set
        {
            if(value is null)
            {
                playerSkill.EquipSkill(equipIndex, null);
                defaultIconImage.enabled = true;
                coolTimeImage.enabled = false;
                base.Skill = value;
            }
            else
            {
                playerSkill.EquipSkill(equipIndex, value as Skill);
                defaultIconImage.enabled = false;
                base.Skill = value;
                coolTimeImage.enabled = true;
                skillCooltime.StartCooltime();
            }
        }
    }
}

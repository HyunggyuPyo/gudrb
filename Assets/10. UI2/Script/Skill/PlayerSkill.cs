using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Skill[] skills = new Skill[3];

    public void EquipSkill(int index, Skill skill)
    {
        if (index > skills.Length) return;

        skills[index] = skill;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    internal Skill skill = null;

    void Start()
    {
        Skill = skill;
    }

    public virtual Skill Skill
    {
        get { return skill; }
        set
        {
            skill = value;
            if(skill == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = skill.iconSprite;
            }
        }
    }

    public bool hasSkill { get { return skill != null; } }

    public void OnDrag(PointerEventData eventData)
    {
        if (!hasSkill)
        {
            return;
        }

        iconImage.rectTransform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!hasSkill)
        {
            return;
        }

        iconImage.rectTransform.SetParent(SkillManager.Instance.skillPage);

        SkillManager.Instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!hasSkill)
        {
            return;
        }

        if(SkillManager.Instance.focusedSlot != this && SkillManager.Instance.focusedSlot != null)
        {
            SkillInventorySlot targetSlot = SkillManager.Instance.focusedSlot;

            Skill tempSkill = targetSlot.Skill;

            targetSlot.Skill = skill;

            this.Skill = tempSkill;
        }

        SkillManager.Instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);

        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillManager.Instance.focusedSlot = null;
    }
}

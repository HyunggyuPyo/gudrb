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
        if (!hasSkill) return;

        iconImage.rectTransform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!hasSkill) return;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!hasSkill) return;

        iconImage.rectTransform.SetParent(SkillManager.Instance.skillPage);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}

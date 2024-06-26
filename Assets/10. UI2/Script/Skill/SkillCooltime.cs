using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooltime : MonoBehaviour
{
    private float cooltime;
    private Image cooltimeImage;
    private Transform parentTranform;

    private void Awake()
    {
        cooltimeImage = this.GetComponent<Image>();
        cooltimeImage.enabled = false;
    }

    public void StartCooltime()
    {
        StartCoroutine(Cooltime());
    }

    IEnumerator Cooltime()
    {
        cooltime = 1f;
        transform.SetAsLastSibling();
        //cooltimeImage.rectTransform.SetParent(transform);

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            cooltime -= 0.1f;
            cooltimeImage.fillAmount = cooltime;

            if (cooltime <= 0)
            {
                cooltimeImage.enabled = false;
                break;
            }
        }
    }
}

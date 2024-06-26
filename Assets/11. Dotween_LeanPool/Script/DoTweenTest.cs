using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenTest : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        DOTween.To
        (
            () => 0f, 
            x => 
            { 
                Vector3 start = Vector3.right * (Time.time - 1f);
                Vector3 end = start + Vector3.up * x;
                Debug.DrawLine(start, end, Color.red, 10);
            },
            1f,
            1f
        ).SetEase(Ease.OutBack);
    }

    // 버튼에서 on Cilck으로 호출할 public 함수
    public void DoPunch(Transform target)
    {
        // target의 원래 사이즈로 돌아감
        target.DOComplete();

        target.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
    }

    public void DoShake(Transform target)
    {
        target.DOComplete();

        target.DOShakePosition(1f, 10);

        target.DOShakeRotation(1f, 40);
    }

    public void DoMove(Transform target)
    {
        target.DOComplete();
                                                           // 보간 수치 함수를 ease로 표현
        target.DOMove(target.position + (Vector3.up * 10), 1).SetEase(Ease.InOutQuad);
    }

    public void DoColor(Graphic target)
    {
        target.DOComplete();
        target.DOColor(new Color(Random.value, Random.value, Random.value), 1f);
    }
}

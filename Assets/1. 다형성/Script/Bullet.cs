using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    void OnTriggerEnter(Collider other)
    {
        // 크리거 안에 들어온 다른 객체의 Layer가 targetLayer와 다른 레이어면 무시
        if((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        //interface를 활용한 방법
        if (other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(damage);
        }

        //sendMessge를 활용한 방법
        // 위에 코드가 정석이지만 혼자 빠르게 개발할때 이렇게 간단하게도 가능 단, 회사에서 이럼 욕 먹음
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);


        Destroy(gameObject);
    }
}

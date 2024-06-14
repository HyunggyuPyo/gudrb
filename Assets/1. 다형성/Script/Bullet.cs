using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    void OnTriggerEnter(Collider other)
    {
        // ũ���� �ȿ� ���� �ٸ� ��ü�� Layer�� targetLayer�� �ٸ� ���̾�� ����
        if((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        //interface�� Ȱ���� ���
        if (other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(damage);
        }

        //sendMessge�� Ȱ���� ���
        // ���� �ڵ尡 ���������� ȥ�� ������ �����Ҷ� �̷��� �����ϰԵ� ���� ��, ȸ�翡�� �̷� �� ����
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);


        Destroy(gameObject);
    }
}

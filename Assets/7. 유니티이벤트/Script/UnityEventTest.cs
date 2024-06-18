using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    private float maxHP = 100F;
    private float currentHP = 100f;
    private float hpCache = 100f;

    //����Ƽ �̺�Ʈ (UnityEvent)
    //����Ƽ Inspector���� ��������Ʈ�� ���� Ư�� �Լ��� ����Ͽ� ȣ�� �� �� �ֵ��� ������� Ŭ���� 
    public UnityEvent someEvent;
    public UnityEvent<float> onHPChange;
    public UnityEvent<string> onHPChangeString;

    public void SomeMethod()
    {
        print("Some Event Called.");
    }

    private void Start()
    {
        onHPChange.AddListener(PrintCurrentHP);
        
    }

    public void OnValueChanged(float value)
    {
        print(value);
    }

    public void PrintCurrentHP(float value)
    {
        print($"current Hp Amount is : {value}");
    }

    public void OnPositionChange(Vector2 value)
    {
        transform.position = value;
    }

    public void OnDamageButtonClick()
    {
        currentHP -= 10f;
    }
    private void Update()
    {
        if(hpCache != currentHP)
        {
            //hp ���� �ٲ����
            onHPChange?.Invoke(currentHP/maxHP);
            onHPChangeString?.Invoke((currentHP/maxHP).ToString("p1"));
            hpCache = currentHP;
        }
    }
}

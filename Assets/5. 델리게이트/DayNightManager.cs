using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    // �̱��� 
    public static DayNightManager Instance { get; private set; }

    public Transform lightTransform; //Directional Light ������Ʈ ����

    private bool isDay = true; //���̸� true, ���̸� false

    //observer Pattern�� �κ������� ����
    public System.Action<bool> onDayComesUp;
    //����Ƽ���� ������ ���� ���� �� delegate �Ǵ� eventHandler�� �ַ� Ȱ��

    private void Awake()
    {
        Instance = this;
        onDayComesUp = (isDay) => 
        {
            lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0); 
        };
    }

    public void DayToggleButtonClick() // �㳷 ��� ��ư�� ȣ��
    {
        isDay = !isDay; //isDay ���
        onDayComesUp?.Invoke(isDay);

        
    }
}

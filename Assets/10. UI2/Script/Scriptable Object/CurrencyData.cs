using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Coin,
    Food,
    Wood,
    Metal,
    Crystal
}

//�Լ� �Ǵ� ������ ȣ�� �� [�Ķ���� �̸�] = [��] ���·� �Ķ���� ������ ������� ���� ����
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Object/CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    //��ȭ �����͸� ����ȭ �� Scriptable object
    public string currencyName;
    public Sprite iconSprite;
    public CurrencyType currencyType;
    public int maxCount;
}

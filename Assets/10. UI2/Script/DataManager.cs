using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� �����͸� �����ϴ� Ŭ���� 

public class PlayerData2
{
                                      // Enum.GetValue : ������ Ÿ�� ���� ��� ���θ� �������� �Լ�
    private int[] currencyArray = new int[System.Enum.GetValues(typeof(CurrencyType)).Length];
    
    public int this[CurrencyType type]
    {
        get { return currencyArray[(int)type]; }
        set { currencyArray[(int)type] = value; }
    }
}

public class DataManager : MonoBehaviour
{
    public List<CurrencyData> currencyDataList;
    public UICurrencyList currencyList;

    public static DataManager Instance { get; private set; }

    public PlayerData2 playersData = new PlayerData2();

    public System.Action<CurrencyType, int> onCurrenctAniubtChange; //delegate

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //foreach(CurrencyData currencyData in currencyDataList)
        //{
        //    print(currencyData.currencyName);
        //}

        currencyList.Initialize();
    }

    public void AddCurrency(int param)
    {
        CurrencyType type = (CurrencyType)param;

        playersData[type]++;

        onCurrenctAniubtChange?.Invoke(type, playersData[type]);

        print($"{type} ��� : {playersData[type]}");
    }

    public void AddCurrency(CurrencyType type, int amount)
    {
        playersData[type] += amount;
        onCurrenctAniubtChange?.Invoke(type, playersData[type]);

        print($"{type} ��� : {playersData[type]}");
    }
}

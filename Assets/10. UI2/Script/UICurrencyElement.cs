using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICurrencyElement : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    private CurrencyData data;

    public void SetData(CurrencyData data)
    {
        this.data = data;
        // currency element �� �����ǵ� ���� ȣ�� �� �ʱ�ȭ �Լ�.

        iconImage.sprite = data.iconSprite; // ������ ��ü
        nameText.text = data.currencyName; // �̸� ����

        // ����� �ּ�/�ִ밪 �Ҵ�
        progressBar.minValue = 0; 
        progressBar.maxValue = data.maxCount;

        int currentCount = DataManager.Instance.playersData[data.currencyType];

        // ����� �ؽ�Ʈ ����
        progressText.text = $"{currentCount} / {data.maxCount.ToString()}";

        // ����� ���簪 �Ҵ�
        progressBar.value = currentCount;

        // ��ȭ ���� ���� �� �� ȣ��ǵ��� delegate stack�� �߰�
        DataManager.Instance.onCurrenctAniubtChange += OnCurrencyAmountChange;
    }

     public void OnCurrencyAmountChange(CurrencyType type, int count)
    {
        if(type == data.currencyType)
        {
            progressBar.value = count;
            progressText.text = $"{count} / {data.maxCount.ToString()}";
        }
    }
}

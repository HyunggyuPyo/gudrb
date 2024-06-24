using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTest : MonoBehaviour
{
    public Toggle[] toggles;

    void Awake()
    {
        toggles = GetComponentsInChildren<Toggle>();
    }

    
    void Start()
    {
        for(int i =0; i < toggles.Length; i++)
        {
            // i ������ ������ ���, ��� ������ ���� �� ������ ���� �ٲ�� ������ 
            // �ش� ���������� i���� stack�� ������ ĸ���ϱ� ���Ͽ� ���� 1���� �����.
            int index = i;

            toggles[i].onValueChanged.AddListener
                (
                    delegate (bool isOn)
                    {
                        if(isOn)
                        {
                            OnToggleValueChange(index);
                        }
                    }
                );
        }
    }

    public void OnToggleValueChange(int index)
    {
        print($"Toggle {index} is On");
    }
}

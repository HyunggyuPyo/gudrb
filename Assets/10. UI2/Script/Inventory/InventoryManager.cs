using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public RectTransform equipPage;
    public RectTransform inventoryContent;

    public int inventorySlotCount; //������ ���� ����
    public InventorySlot inventorySlotPrefab; // ���� ������
    private List<InventorySlot> inventorySlots = new(); // ���� ����Ʈ

    [Space(20)] // �ν�����â���� �� �ٲٱ� ���� �� 
    public InventorySlot focusedSlot;
    public InventorySlot selectedSlot;

    public List<Item> tempItems;
    public List<Weapon> tempWeapons;

    private void Start()
    {
        EquipSlot.a a = new EquipSlot.b();

        //tempItems ����Ʈ�� tempWeapons��ҵ��� 0�� �ε������� ����
        tempItems.InsertRange(0, tempWeapons);

        for(int i = 0; i < tempItems.Count; i++)
        {
            // �ӽ� �������� inventory content ���� ���Կ� �� ���� �Ҵ�
            inventoryContent.GetChild(i).GetComponent<InventorySlot>().Item = tempItems[i];
        }
    }
}

[System.Serializable]
public class Item
{
    public Sprite iconSprite; // ������ ������
    public string name; // ������ �̸� 
    public string desc; // ������ ����
}

[System.Serializable]
public class Weapon : Item
{
    public float damage; // ������ 
    public GameObject equipPrefab; // ���� �� ������ ������ ��� ������
}


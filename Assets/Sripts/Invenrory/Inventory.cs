using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ItemSlot
{
    public ItemData item;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    //UI���԰� �������� Index��ȣ�� ��Ī�ؼ� ����Ѵ�. 
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots; //�̸��� slot�ε� ��ǻ� ������������ �ִ� �����۰���

    public GameObject inventoryWindow;
    private Player player;

    private void Awake()
    {
       Instance = this;
        player = GetComponent<Player>();
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
    }


    public void ToggleInventory()
    {
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    //�����۰����� �����۵������Ҵ� 
    public void AddItem(ItemData item)
    {
        ItemSlot emptyItemslot = GetEmptySlot();
        if(emptyItemslot != null)
        {
            emptyItemslot.item = item;
            emptyItemslot.quantity = 1;
            UpdateUI();
            return;
        }
    }

    //����ִ� �����۰��� Ȯ��
    public ItemSlot GetEmptySlot()
    {
        for(int i=0; i<slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }
        return null;
    }
    
    //�������ִ� �������� �ִٸ� �� ���Կ� �����Ǵ� UISlot�̹��� Ȱ��ȭ. 
    public void UpdateUI()
    {
        for(int i = 0;i < slots.Length;i++)
        {
            if (slots[i].item != null)
            {
                uiSlots[i].Set(slots[i]);
            }
            else uiSlots[i].Clear();
        }
    }

}

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

    //UI슬롯과 아이템은 Index번호로 매칭해서 사용한다. 
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots; //이름은 slot인데 사실상 가지고있을수 있는 아이템공간

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

    //아이템공간에 아이템데이터할당 
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

    //비어있는 아이템공간 확인
    public ItemSlot GetEmptySlot()
    {
        for(int i=0; i<slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }
        return null;
    }
    
    //가지고있는 아이템이 있다면 그 슬롯에 대응되는 UISlot이미지 활성화. 
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

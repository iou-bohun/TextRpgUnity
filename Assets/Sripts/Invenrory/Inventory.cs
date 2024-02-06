using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEditor.Progress;


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

    public int curSelectedItemIndex;
    private ItemSlot curEquipWeapon;
    private ItemSlot curEquipArmor;

    public GameObject inventoryWindow;

    [Header("Item Info Window")]
    public GameObject itemInfo;
    [SerializeField] TextMeshProUGUI itemInfoName;
    [SerializeField] TextMeshProUGUI itemInfoDescription;
    [SerializeField] TextMeshProUGUI itemStatInfo;

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

    public void UpdateItemInfo(ItemData item)
    {
        itemInfo.SetActive(true);
        itemInfoName.text = item.itemName;
        itemInfoDescription.text = item.description;
        itemStatInfo.text = "+ " + ( item.EquipableType == EquipableType.Weapon ? "ATK " + item.ATKValue.ToString() : "DEF " + item.DEFValue.ToString());
    }

    public void ClearItemInfo()
    {
        itemInfo.SetActive(false);
        itemInfoName.text = null;
        itemInfoDescription.text = null;
        itemStatInfo.text = null;
    }

    public void SelectedItem(int index)
    {
        if (slots[index].item == null)
        {
            return;
        }
        else
        {
            curSelectedItemIndex = index;
            if (!uiSlots[curSelectedItemIndex].isEquiped)
            {
                EquipItem();
            }
            else
            {
                UnEquipItem();
            }
            
        }
    }

    void EquipItem()
    {
        uiSlots[curSelectedItemIndex].isEquiped = true;
        player.AddStat(slots[curSelectedItemIndex].item);
        UIController.instance.OnUIUpdateEvent();
        UpdateUI();
    }

    void UnEquipItem()
    {
        uiSlots[curSelectedItemIndex].isEquiped = false;
        player.RemoveStat(slots[curSelectedItemIndex].item);
        UIController.instance.OnUIUpdateEvent();
        UpdateUI();
    }
}

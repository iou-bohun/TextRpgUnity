using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public int index;
    public Image icon;
    private ItemData itemData;
    public bool isEquiped;
    public Outline outline;

    public void Clear()
    {
        icon.gameObject.SetActive(false);
    }

    public void Set(ItemSlot slot)
    {
        this.itemData = slot.item;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
    }

    public void MouseEnter()
    {
        if (this.itemData != null)
        {
            Inventory.Instance.UpdateItemInfo(itemData);
        }
    }
    public void MouseExit()
    {
        Inventory.Instance.ClearItemInfo();
    }

    public void OnClick()
    {
        Inventory.Instance.SelectedItem(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public int index;
    public Image icon;
    private ItemData itemData;
    public bool isEquiped;
    public Outline outline;
    public TextMeshProUGUI equippedText;

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        equippedText.text = null;
    }

    public void Set(ItemSlot slot)
    {
        this.itemData = slot.item;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        if (isEquiped) equippedText.text = "E";
        else equippedText.text = null;
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

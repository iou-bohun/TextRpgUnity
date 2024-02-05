using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUiSlot : MonoBehaviour
{
    public int index;
    public Image icon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStat;
    public TextMeshProUGUI cost;

    public ItemData thisItem;

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        itemName.text = null;
        itemStat.text = null;
        cost.text = null;
    }

    public void Set(ItemData item)
    {
        thisItem = item;
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        itemName.text = item.name;
        itemStat.text = item.EquipableType == EquipableType.Weapon ? "ATK"+item.ATKValue.ToString() : "DEF" + item.DEFValue .ToString();
        cost.text = item.cost.ToString();
    }

    public void BuyItem()
    {
        if(thisItem != null)
        {
            Inventory.Instance.AddItem(thisItem);
        }
        else
        {
            Debug.Log("상품 준비중");
        }
    }
}

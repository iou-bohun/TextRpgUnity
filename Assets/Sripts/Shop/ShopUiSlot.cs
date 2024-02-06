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
    private bool isSlod;

    public ItemData thisItem;

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        itemName.text = null;
        itemStat.text = null;
        cost.text = null;
        isSlod = false;
    }

    public void Set(ItemData item)
    {
        thisItem = item;
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        itemName.text = item.itemName;
        itemStat.text = item.EquipableType == EquipableType.Weapon ? "ATK"+item.ATKValue.ToString() : "DEF" + item.DEFValue .ToString();
        cost.text = "Gold : "+item.cost.ToString();
    }

    public void BuyItem()
    {
        if(thisItem != null)
        {
            if(Bank.instance.CurrentBalance >= thisItem.cost && isSlod == false)
            {
                isSlod = true;
                icon.sprite = null;
                Bank.instance.Withdraw(thisItem.cost);
                Inventory.Instance.AddItem(thisItem);
                UIController.instance.CallUiUpdateEvent();
            }
            else
            {
                Debug.Log("골드가 부족합니다. ");
            }
        }
        else
        {
            Debug.Log("상품 준비중!");
        }
        
    }
}

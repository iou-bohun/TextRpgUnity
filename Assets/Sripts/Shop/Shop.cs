using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopSlot
{
    public ItemData item;
    public bool isSold = false;
}

public class Shop : MonoBehaviour
{
    public GameObject shopWindow;

    public ShopUiSlot[] uiSlots;
    public ItemData[] items; //상정의 아이템들

    private void Awake()
    {
        
    }

    private void Start()
    {
        shopWindow.SetActive(false);

        for(int i = 0; i< uiSlots.Length; i++)
        {

            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        SetItemData();
    }

    public void ToggleShopWindow()
    {
        if (shopWindow.activeInHierarchy)
        {
            shopWindow.SetActive(false);
        }
        else
        {
            shopWindow.SetActive(true);
        }
    }

    public void SetItemData()
    {
        for(int i= 0; i< items.Length; i++)
        {
            uiSlots[i].Set(items[i]);
        }
    }
}

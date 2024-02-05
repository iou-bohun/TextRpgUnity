using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resources,
}

public enum EquipableType
{
    Weapon,
    Armor,
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public int cost;


    [Header("Equipable")]
    public EquipableType EquipableType;
    public int ATKValue;
    public int DEFValue;

    public ItemData(string name, Sprite icon)
    {
        this.itemName = name;
        this.icon = icon;
    }
}

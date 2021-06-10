using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]

public class EquipmentObject : ItemObject
{
    //public float atkBonus;
    //public float defenceBonus;
    public void Awake()
    {
        type = ItemType.Chest;
        type = ItemType.Legs;
        type = ItemType.Helmet;
        type = ItemType.Boots;
        type = ItemType.Belt;
        type = ItemType.Gloves;
        type = ItemType.Backpack;
        type = ItemType.Shield;
        type = ItemType.Weapon;
    }
}

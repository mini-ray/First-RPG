using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public InventoryObject inventory;
    public InventoryObject equipment;

    public Attribute[] attributes;

    private void Start()
    {
        for(int i = 0; i < equipment.GetSlots.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for(int i = 0; i < equipment.GetSlots.Length; i++)
        {
            //equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            //equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Touching");
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            if(inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            inventory.Save();
            equipment.Save();
            //Debug.Log("Inventory Saved");
        }
        if (Input.GetKeyDown("p"))
        {
            inventory.Load();
            equipment.Load();
            //Debug.Log("Inventory Loaded");
        }
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, "was updated! Value is now ", attribute.value.ModifiedValue));
    }

    //private void OnApplicationAwake()
    //{
    //    inventory.Container.Items = new InventorySlot[5];
    //}

    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(Player _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}

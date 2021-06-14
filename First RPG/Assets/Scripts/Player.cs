using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject CanvasObject;

    public bool inventoryopen;
    public InventoryObject inventory;
    public InventoryObject equipment;

    public Attribute[] attributes;

    private void Start()
    {
        for(int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for(int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items", string.Join(", ", _slot.AllowedItems)));
                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
        }
    }

    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items", string.Join(", ", _slot.AllowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Chest:
                break;
            default:
                break;
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

        OpenInventory();

        if(inventoryopen == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            //Debug.Log("Inventory Open");
        }
        if (inventoryopen == false)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            //Debug.Log("Inventory Closed");
        }
    }

    public void OpenInventory()
    {
        if (inventoryopen = false && Input.GetKeyUp(KeyCode.E))
        {
            inventoryopen = true;
            Debug.Log("E");
        }
        if(inventoryopen = true && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryopen = false;
            Debug.Log("E");
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
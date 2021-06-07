using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public InventoryObject inventory;
    public InventoryObject equipment;

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
            Debug.Log("Inventory Saved");
        }
        if (Input.GetKeyDown("p"))
        {
            inventory.Load();
            equipment.Load();
            Debug.Log("Inventory Loaded");
        }
    }

    //private void OnApplicationAwake()
    //{
    //    inventory.Container.Items = new InventorySlot[5];
    //}

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        equipment.Container.Clear();
    }

}

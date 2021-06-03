using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Touching");
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            Debug.Log(_item.Id);
            inventory.AddItem(_item, 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            inventory.Save();
            Debug.Log("Inventory Saved");
        }
        if (Input.GetKeyDown("p"))
        {
            inventory.Load();
            Debug.Log("Inventory Loaded");
        }
    }

    //private void OnApplicationAwake()
    //{
    //    inventory.Container.Items = new InventorySlot[5];
    //}

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[36];
    }

}

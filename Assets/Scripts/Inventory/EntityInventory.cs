using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            Debug.Log("Saved");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
            Debug.Log("Loaded");
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}

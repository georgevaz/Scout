using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;
public class EntityInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;
    public ItemAttributes[] attributes;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            equipment.Save();

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
            equipment.Load();

        }
    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }

    public void AttributeModified(Attribute attribute){
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
    }
}

[Serializable]
public class Attribute{
    [NonSerialized]
    public EntityInventory parent;
    public ItemAttributes type;
    public ModifiableInt value;
    public void SetParent(EntityInventory _parent){
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }

    public void AttributeModified(){
        parent.AttributeModified(this);
    }
}
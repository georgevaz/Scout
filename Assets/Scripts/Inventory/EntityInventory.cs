using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;
public class EntityInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;
    public Attribute[] attributes;

    private void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
        {
            return;
        }

        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));
                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                        {
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                        }
                    }
                }

                var gun = this.transform.Find("CameraHolder/LeanPivot/Weapon/WeaponSway/WeaponAnimations/" + _slot.ItemObject.name);
                if (gun != null)
                {
                    gun.gameObject.SetActive(false);
                }

                break;
            default:
                break;
        }

    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));
                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                        {
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                        }
                    }
                }

                var gun = this.transform.Find("CameraHolder/LeanPivot/Weapon/WeaponSway/WeaponAnimations/" + _slot.ItemObject.name);
                if (gun != null)
                {
                    gun.gameObject.SetActive(true);
                }
                
                break;
            default:
                break;
        }

    }

    // public void OnTriggerEnter(Collider other)
    // {
    //     var item = other.GetComponent<GroundItem>();
    //     if (item)
    //     {
    //         Item _item = new Item(item.item);
    //         if (inventory.AddItem(_item, 1))
    //         {
    //             Destroy(other.gameObject);
    //         }

    //     }
    // }

    public void PickUpItem(Collider other)
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

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
    }
}

[Serializable]
public class Attribute
{
    [NonSerialized]
    public EntityInventory parent;
    public ItemAttributes type;
    public ModifiableInt value;
    public void SetParent(EntityInventory _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public abstract class UserInterface : MonoBehaviour
{
    public EntityInventory entityInventory;
    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    void Start()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            inventory.Container.Items[i].parent = this;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }


    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in slotsOnInterface)
        {
            if (_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.GetChild(0).transform.GetComponent<Image>().sprite = _slot.Value.ItemObject.icon;
                _slot.Key.transform.GetChild(0).transform.GetComponent<Image>().color = new Color(1, 1, 1, 1); // This is only needed if the empty slot has a different alpha value
                _slot.Key.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.database.GetItem[_slot.Value.item.Id].name.ToString();
                _slot.Key.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).transform.GetComponent<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).transform.GetComponent<Image>().color = new Color(1, 1, 1, 0); // This is only needed if the empty slot has a different alpha value
                _slot.Key.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                _slot.Key.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";

            }
        }
    }

    public abstract void CreateSlots();


    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }
    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
    }
    public void OnExit(GameObject obj)
    {
        MouseData.slotHoveredOver = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);
        mouseObject.transform.SetParent(transform.parent);

        if (slotsOnInterface[obj].item.Id >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = slotsOnInterface[obj].ItemObject.icon;
            img.raycastTarget = false;
        }
        MouseData.tempItemBeingDragged = mouseObject;
    }
    public void OnDragEnd(GameObject obj)
    {
        Destroy(MouseData.tempItemBeingDragged);
        if (MouseData.interfaceMouseIsOver == null)
        {
            slotsOnInterface[obj].RemoveItem();
            return;
        }
        if (MouseData.slotHoveredOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            // inventory.MoveItem
        }
        // if (itemOnMouse.ui != null)
        // {
        //     if (mousehoverObj && itemOnMouse.item.ID != -1)
        //     {

        //         if (mouseHoverItem.CanPlaceInSlot(GetItemObject[slotsOnInterface[obj].ID]) && (mouseHoverItem.item.Id <= -1 || (mouseHoverItem.item.Id >= 0 && slotsOnInterface[obj].CanPlaceInSlot(GetItemObject[mouseHoverItem.item.Id]))))
        //         {
        //             inventory.MoveItem(slotsOnInterface[obj], mouseHoverItem.parent.slotsOnInterface[itemOnMouse.hoverObj]);
        //         }
        //     }
        // }
        // else
        // {
        //     inventory.RemoveItem(slotsOnInterface[obj].item);
        // }

    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


    // private void CreateSlot(InventorySlot slot, int i)
    // {
    //     var obj = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, transform);
    //     obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
    //     obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = inventory.database.GetItem[slot.item.Id].icon;
    //     obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.database.GetItem[slot.item.Id].name.ToString();
    //     obj.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
    //     slotsOnInterface.Add(slot, obj);
    // }
}

public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
}

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
    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    void Start()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            inventory.Container.Items[i].parent = this;
        }
        CreateSlots();
    }


    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).transform.GetComponent<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].icon;
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

    public void OnEnter(GameObject obj)
    {
        entityInventory.mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            entityInventory.mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        entityInventory.mouseItem.hoverObj = null;
        entityInventory.mouseItem.hoverItem = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);
        mouseObject.transform.SetParent(transform.parent);

        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].icon;
            img.raycastTarget = false;
        }
        entityInventory.mouseItem.obj = mouseObject;
        entityInventory.mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (entityInventory.mouseItem.hoverObj && entityInventory.mouseItem.item.ID != -1)
        {
            inventory.MoveItem(itemsDisplayed[obj], entityInventory.mouseItem.hoverItem.parent.itemsDisplayed[entityInventory.mouseItem.hoverObj]);
        }
        else
        {
            inventory.RemoveItem(itemsDisplayed[obj].item);
        }
        Destroy(entityInventory.mouseItem.obj);
        entityInventory.mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if (entityInventory.mouseItem.obj != null)
        {
            entityInventory.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


    // private void CreateSlot(InventorySlot slot, int i)
    // {
    //     var obj = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, transform);
    //     obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
    //     obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = inventory.database.GetItem[slot.item.Id].icon;
    //     obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.database.GetItem[slot.item.Id].name.ToString();
    //     obj.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
    //     itemsDisplayed.Add(slot, obj);
    // }
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public GameObject hoverObj;
    public InventorySlot hoverItem;
}

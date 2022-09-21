using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DynamicInterface : UserInterface
{
    public GameObject inventorySlot;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int numberOfColumns;
    public int ySpaceBetweenItems;
    private float gridWidth;
    private float gridHeight;

    public override void CreateSlots()
    {
        // Using these variables to calculate x and y start variables to begin at top left of interface
        gridWidth = transform.GetComponent<RectTransform>().sizeDelta.x;
        gridHeight = transform.GetComponent<RectTransform>().sizeDelta.y;
        
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i, obj);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            inventory.GetSlots[i].slotDisplay = obj;

            slotsOnInterface.Add(obj, inventory.GetSlots[i]);
        }
    }

    private Vector3 GetPosition(int i, GameObject obj)
    {
        var itemSlotWidth = obj.GetComponent<RectTransform>().sizeDelta.x;
        var itemSlotHeight = obj.GetComponent<RectTransform>().sizeDelta.y;

        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)) + -(gridWidth / 2) + (itemSlotWidth / 2), yStart + ((-ySpaceBetweenItems * (i / numberOfColumns))) + (gridHeight / 2) + -(itemSlotHeight / 2), 0f);
    }
}

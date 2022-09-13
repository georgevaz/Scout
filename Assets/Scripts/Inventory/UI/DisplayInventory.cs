using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventorySlot;
    public InventoryObject inventory;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int numberOfColumns;
    public int ySpaceBetweenItems;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }


    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            if (itemsDisplayed.ContainsKey(slot)){
                itemsDisplayed[slot].transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }
            else
            {
                CreateSlot(slot, i);
                
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            CreateSlot(slot, i);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)), yStart + ((-ySpaceBetweenItems * (i / numberOfColumns))), 0f);
    }

    private void CreateSlot(InventorySlot slot, int i)
    {
        var obj = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = inventory.database.GetItem[slot.item.Id].icon;
        obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.database.GetItem[slot.item.Id].name.ToString();
        obj.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        itemsDisplayed.Add(slot, obj);
    }
}

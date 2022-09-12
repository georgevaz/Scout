using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int numberOfColumns;
    public int ySpaceBetweenItems;
    public GameObject inventorySlot;
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
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i])){
                itemsDisplayed[inventory.Container[i]].transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                CreateSlot(i);
                
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            CreateSlot(i);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)), yStart + ((-ySpaceBetweenItems * (i / numberOfColumns))), 0f);
    }

    private void CreateSlot(int i)
    {
        var obj = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = inventory.Container[i].item.icon;
        obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventory.Container[i].item.name.ToString();
        obj.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        itemsDisplayed.Add(inventory.Container[i], obj);
    }
}

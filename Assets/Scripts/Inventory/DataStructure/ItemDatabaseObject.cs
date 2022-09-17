using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] ItemsObjects;
    [ContextMenu("Update IDs")]
    public void UpdateID()
    {
        for (int i = 0; i < ItemsObjects.Length; i++)
        {
            if (ItemsObjects[i].data.Id != i)
            {
                ItemsObjects[i].data.Id = i;
            }

        }

    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }
    public void OnBeforeSerialize()
    {

    }
}

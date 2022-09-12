using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}

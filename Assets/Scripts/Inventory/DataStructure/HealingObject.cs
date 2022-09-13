using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

[CreateAssetMenu(fileName = "New Healing Object", menuName = "Inventory System/Items/Healing")]
public class HealingObject : ItemObject
{

    public void Awake()
    {
        type = Models.ItemType.Healing;
    }
}

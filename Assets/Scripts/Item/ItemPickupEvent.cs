using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupEvent
{
    public ItemData itemData;
    public ItemPickupEvent(ItemData data)
    {
        itemData = data;
    }
}
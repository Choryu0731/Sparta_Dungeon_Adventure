using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public List<ItemData> inventory = new();

    public ItemUIController uiController;

    void OnEnable()
    {
        EventBus.Subscribe<ItemPickupEvent>(OnItemPickup);
    }

    void OnDisable()
    {
        EventBus.Unsubscribe<ItemPickupEvent>(OnItemPickup);
    }

    void OnItemPickup(ItemPickupEvent e)
    {
        if (inventory.Count < 3)
        {
            inventory.Add(e.itemData);
            uiController.AddItem(e.itemData);
        }
    }

    public ItemData GetItem(int index)
    {
        return index < inventory.Count ? inventory[index] : null;
    }

    public void RemoveItem(int index)
    {
        if (index < inventory.Count)
            inventory.RemoveAt(index);
    }
}

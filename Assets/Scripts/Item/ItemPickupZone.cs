using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupZone : MonoBehaviour
{
    public ItemData item;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Publish(new ItemPickupEvent(item));
            Destroy(gameObject);
        }
    }
}

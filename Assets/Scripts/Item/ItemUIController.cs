using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ItemUIController : MonoBehaviour
{
    public List<Image> itemSlotImages;
    public Sprite defaultIcon;
    public int currentIndex = 0;

    private List<ItemData> localInventory = new();

    public void AddItem(ItemData item)
    {
        if (localInventory.Count < 3)
        {
            localInventory.Add(item);
            UpdateUI();
        }
    }

    public void SwitchNextItem()
    {
        if (localInventory.Count == 0) return;
        currentIndex = (currentIndex + 1) % localInventory.Count;
        UpdateUI();
    }

    public void OnItemUsed(int index)
    {
        if (index < localInventory.Count)
            localInventory.RemoveAt(index);

        if (currentIndex >= localInventory.Count)
            currentIndex = 0;

        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlotImages.Count; i++)
        {
            if (i < localInventory.Count)
            {
                var item = localInventory[(currentIndex + i) % localInventory.Count];
                itemSlotImages[i].sprite = item.icon;
                itemSlotImages[i].enabled = true;
                itemSlotImages[i].rectTransform.localScale = (i == 0) ? Vector3.one * 1.3f : Vector3.one;
            }
            else
            {
                itemSlotImages[i].sprite = defaultIcon;
                itemSlotImages[i].enabled = false;
                itemSlotImages[i].rectTransform.localScale = Vector3.one;
            }
        }
    }
}
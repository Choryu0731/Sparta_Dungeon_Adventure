using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ItemInputController : MonoBehaviour
{
    public ItemInventory inventory;
    public ItemUseSystem itemUser;
    public ItemUIController uiController;

    public void OnUseItem1(InputAction.CallbackContext context)
    {
        if (context.performed)
            Use(0);
    }

    public void OnUseItem2(InputAction.CallbackContext context)
    {
        if (context.performed)
            Use(1);
    }

    public void OnUseItem3(InputAction.CallbackContext context)
    {
        if (context.performed)
            Use(2);
    }

    public void OnUseSelected(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            int index = uiController.currentIndex;
            Use(index);
        }
    }

    public void OnNextItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            uiController.SwitchNextItem();
        }
    }

    void Use(int index)
    {
        var item = inventory.GetItem(index);
        if (item != null)
        {
            itemUser.Use(item);
            inventory.RemoveItem(index);
            uiController.OnItemUsed(index);
        }
    }
}
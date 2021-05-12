
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //This script will keep track of everything that will happen at a slot
    //This includes the UI and the mechanics e.g. if it is pressed

    //create a variable called item to keep track of the current item in the slot
    Item item;
    public Button removeButton;

    public Image icon; // icon on the slot

    //Add item to the slot
    public void AddItem(Item newItem)
    {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }
    // Remove an item from the slot
    public void ClearSlot () {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton () {
        Inventory.instance.Remove(item);
    }

    public void UseItem () {
        if (item != null) 
        {
            item.Use();
        }
    }
}

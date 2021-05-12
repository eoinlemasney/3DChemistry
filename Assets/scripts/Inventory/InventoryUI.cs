
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    //cache the inventory
    Inventory inventory;

    //Reference the inventory parent so that we get all chiild slots
    public Transform itemsParent;
    InventorySlot[] slots;
    void Start() 
    {
        //singleton reference
       inventory = Inventory.instance;
       // Use the inventory callback methd
       inventory.onItemChangedCallback += UpdateUI;
    // Only needs to be done once as the inventory slots stay the same
       slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            // set it to the reversed state, if active then deactivate it etc.
            inventoryUI.SetActive (!inventoryUI.activeSelf);
        }

    }

        void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // check if there are more items to add
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("Updating UI!");
    }
}


using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //cache the inventory
    Inventory inventory;
    void Start() 
    {
        //singleton reference
       inventory = Inventory.instance;
       // Use the inventory callback methd
       inventory.onItemChangedCallback += UpdateUI;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

        void UpdateUI()
    {
        Debug.Log("Updating UI!");
    }
}

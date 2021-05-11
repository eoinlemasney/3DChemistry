
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inventory;
    void Start() 
    {
        //singleton refernece
       inventory = Inventory.instance; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

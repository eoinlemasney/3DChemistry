
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    //overide the function in the parent class
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Pick up item " + item.name);
        //create a reference to the inventory.. use the Singleton created
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }

}

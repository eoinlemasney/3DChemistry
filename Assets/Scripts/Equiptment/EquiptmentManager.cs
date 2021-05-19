using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquiptmentManager : MonoBehaviour
{
    public static EquiptmentManager instance;
    Equiptment[] currentEquiptment;

    //To display the changes on thte character when equipted, a call back method is used
    public delegate void OnEquiptmentChanged(Equiptment newItem, Equiptment oldItem);
    //Allow other scrtipts to access this call back method
    public OnEquiptmentChanged onEquiptmentChanged;

    Inventory inventory;


    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        inventory = Inventory.instance;
        //Get the number of elements in an enum
        int numSlots = System.Enum.GetNames(typeof(EquiptmentSlot)).Length;
        currentEquiptment = new Equiptment[numSlots];
    }

    public void Equip(Equiptment newItem)
    {
        // get index of where the item is inserted into
        int slotIndex = (int)newItem.equiptSlot;

        //Get reference to the old item
        Equiptment oldItem = null;

        // check if item of this type is already in the slot
        if (currentEquiptment[slotIndex] != null)
        {
            oldItem = currentEquiptment[slotIndex];
            inventory.Add(oldItem);

        }

        if (onEquiptmentChanged != null)
        {
            onEquiptmentChanged.Invoke(newItem, oldItem);
        }

        //Set the equiptment slot to this new item
        currentEquiptment[slotIndex] = newItem;


    }
    public void Unequip(int slotIndex)
    {
        if (currentEquiptment[slotIndex] != null)
        {
            // Get the old item and set the current equiptment tot his slot
            Equiptment oldItem = currentEquiptment[slotIndex];
            inventory.Add(oldItem);
            currentEquiptment[slotIndex] = null;

            if (onEquiptmentChanged != null)
            {
                onEquiptmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        // Unequip all items
        for (int i = 0; i < currentEquiptment.Length; i++)
        {
            Unequip(i);

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}

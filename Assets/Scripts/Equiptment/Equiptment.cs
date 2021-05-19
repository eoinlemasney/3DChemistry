using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equiptment", menuName = "Inventory/ Equiptment")]
public class Equiptment : Item
{
    public EquiptmentSlot equiptSlot;

    public int increaseModifier;
    public int decreaseModifier;

    public override void Use()
    { 
        base.Use();
        // Equipt and remove item from the inventory
        EquiptmentManager.instance.Equip(this);
        RemoveFromInventory();

         }

}

// This is where the equiptment is stored
public enum EquiptmentSlot { Pocket, Chest, Legs, Weapon, Backpack }

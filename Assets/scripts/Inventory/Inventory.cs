using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //create a singleton pattern to have a reference to the inventory
    //create a static variable which is shared by all instances of the class
    //when we start the game, the instance is set to this inventory
    //therefore we only have one inventory at all times

    #region Singleton
    //A Delegate is a reference pointer to a method. It allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate
    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;
    public int space = 9;
    public static Inventory instance;

    public List<Item> itemsRequired = new List<Item>();

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    #endregion
    public List<Item> items = new List<Item>();
    public List<Item> itemsUsed = new List<Item>();


    public bool Add(Item item)
    {
        //dont add the them if it is default

        if (!item.isDefaultItem)
        {
            //checks if there is nenough room in the inventory
            if (items.Count >= space)
            {
                Debug.Log("Not enough room in inventory");
                return false;
            }
            items.Add(item);
            //will be used for the inventory ui
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();


        }
        return true;

    }

    public void Remove(Item item)
    {
        //Remove item from the inventory but store it as a used item
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}


﻿
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName ="Inventory/ Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        // function can be overridden depending on what the item is
        //item will be used

        Debug.Log("Using " + name);
    }

}

using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName ="Inventory/ Item")]
public class Item : ScriptableObject
{

    new public string name = "New Ite";
    public Sprite icon = null;
    public bool isDefaultItem = false;

}

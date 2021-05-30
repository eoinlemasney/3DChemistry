
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/ Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public string additionalInfo = "";

    public virtual void Use()
    {

        GameObject thePlayer = GameObject.Find("GameManager");
        Inventory playerScript = thePlayer.GetComponent<Inventory>();
        int ItemsUsedcount = playerScript.itemsUsed.Count;
        Debug.Log("ITEMS USED");
         Debug.Log(ItemsUsedcount);

        var index = ItemsUsedcount;



        if (index == 0)
        {
            if (name != "Chemistry Book")
            {
                UseItem.instance.WrongOrder();
                return;
            }
            else
            {
                UseItem.instance.ReadBook();
                RemoveFromInventory();
                return;


            }
        }




        else if (playerScript.itemsRequired[index].name != name)
        {
            Debug.Log("Should be: " + playerScript.itemsRequired[index].name);
            Debug.Log("Using: " + name);

            UseItem.instance.WrongOrder();
            return;

        }



        if (name == "Chemistry Book")
        {
            UseItem.instance.ReadBook();
        }

        if (name == "Conical Flask")
        {
            if (UseItem.instance.UseConicalFlask())
                RemoveFromInventory();
        }
        else if (name == "Zinc")
        {
            if (UseItem.instance.AddZInc())
                RemoveFromInventory();
        }

        else if (name == "Hydrochloric Acid")
        {
            if (UseItem.instance.AddHCL())
                RemoveFromInventory();
        }

        else if (name == "TestTube")
        {
            if (UseItem.instance.UseTestTube())
                RemoveFromInventory();
        }

        else if (name == "MatchBox")
        {
            if (UseItem.instance.LightMatch())
                RemoveFromInventory();
        }
    }

    public void RemoveFromInventory()
    {
        
        GameObject thePlayer = GameObject.Find("GameManager");
        Inventory playerScript = thePlayer.GetComponent<Inventory>();
        playerScript.itemsUsed.Add(this);
        Inventory.instance.Remove(this);
        Debug.Log(playerScript.itemsUsed);
    }


    public string CallDescription()
    {
        return "You need the " + name + ". " + additionalInfo;

    }

}

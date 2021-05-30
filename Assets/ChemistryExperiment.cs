using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryExperiment : Interactable
{
    //  
    Inventory inventory;

    public Text experimentText;

    string itemsList;


    List<Item> itemsRequired;
    

    private int totalItems;

    public static bool hasItems = false;

    public override void Interact()
    {
        base.Interact();

        DoExperiment();
    }

    void DoExperiment()
    {

        itemsList = "";
        inventory = Inventory.instance;
        itemsRequired = inventory.itemsRequired;
        totalItems = itemsRequired.Count;

        for (int i = 0; i < itemsRequired.Count; i++)
        {

            // Check if the usr has all of the items required to complete the experiment
            if (inventory.items.Contains(itemsRequired[i]))
            { 
                hasItems = true;
                continue;
            }
            else
            {
                hasItems = false;
                if (itemsList != "")
                {
                    itemsList += ", " + itemsRequired[i].name;
                }
                else
                {
                    itemsList += itemsRequired[i].name;

                }

                if (itemsList != "")
                {
                    experimentText.text = "Please find the following items to begin the experiment: " + itemsList;
                    StartCoroutine(experimentText.GetComponent<InstructionText>().FadeTextToZeroAlpha(16f, experimentText)); ;

                }
            }
    
            if (hasItems)
                experimentText.text = "Well done, you found all of the items. Please start the experiment.";



        }
    }
}

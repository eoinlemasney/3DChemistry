using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Teacher : Interactable
{
    Inventory inventory;
    List<Item> itemsRequired;
    public Text  instructionalText;
    
    private int totalItems;
    int counter;

    public override void Interact()
    {
        base.Interact();

        AskForHelp();
    }

void AskForHelp() {
    counter = 0;
    inventory = Inventory.instance;
    itemsRequired = inventory.itemsRequired;
    totalItems = itemsRequired.Count;

    for (int i = 0; i < itemsRequired.Count; i++)
{

    if(inventory.items.Contains(itemsRequired[i])) {
        counter ++;
    } else {
        instructionalText.text = "Task"+ (counter + 1) + ".     "+itemsRequired[i].CallDescription();
        StartCoroutine(instructionalText.GetComponent<InstructionText>().FadeTextToZeroAlpha(8f,instructionalText));;
        break;
    }


    
}

    if (ChemistryExperiment.hasItems)
        instructionalText.text = "Well done, you found all of the items. Please start the experiment.";
    
}

}

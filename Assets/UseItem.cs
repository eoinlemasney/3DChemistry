using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{

    public static UseItem instance;
    public Text experimentText;
    public GameObject testTube;
    public GameObject conicalFlask;
    public GameObject zinc;
    public GameObject hcl;
    public GameObject matches;
    public AudioClip impact;
    AudioSource audioSource;



    // Start is called before the first frame update

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public void ReadBook()
    {
        experimentText.text = "1. Add Zinc to the bottom of a Flask.\n2. Add the HCL to the test tube. \n3. Collect the gas given off in a Test Tube. \n4. Test the gas; it burns with a ‘pop’ showing that the gas is hydrogen";

    }

    public bool UseConicalFlask()
    {
        if (ChemistryExperiment.hasItems)
        {
            conicalFlask.SetActive(true);
            experimentText.text = "Placing down the Concial Flask";
            return true;
        }
        else
        {
            experimentText.text = "You must collect all of the items first";
            return false;


        }
    }


    public bool AddZInc()
    {
        if (ChemistryExperiment.hasItems)
        {
            zinc.SetActive(true);
            experimentText.text = "Adding the Zinc to the Concial Flask";
            return true;
        }
        else
        {
            experimentText.text = "You must collect all of the items first";
            return false;

        }
    }

    public bool AddHCL()
    {
        if (ChemistryExperiment.hasItems)
        {
            hcl.SetActive(true);
            experimentText.text = "Adding the HCL to the Concial Flask";
            return true;
        }
        else
        {
            experimentText.text = "You must collect all of the items first";
            return false;

        }
    }


public bool LightMatch()
{
    if (ChemistryExperiment.hasItems)
    {
        matches.SetActive(true);
        experimentText.text = "Lighting a match to the gas... Well done, You succesfully completed the experiment.";
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(impact, 0.7F);
        return true;
    }
    else
    {
        experimentText.text = "You must collect all of the items first";
        return false;

    }
}

public bool UseTestTube()
{
    if (ChemistryExperiment.hasItems)
    {
        testTube.SetActive(true);
        experimentText.text = "Collecting gas with the test tube";
        return true;
    }
    else
    {
        experimentText.text = "You must collect all of the items first";
        return false;

    }

}

public void WrongOrder()
{
    if (ChemistryExperiment.hasItems)
    {
        experimentText.text = "Read the Chemistry book. You are using the items in the wrong order.";
    }
    else
    {
        experimentText.text = "You must collect all of the items first";
    }

}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    //Get the reference of the destroyed prefab
    public GameObject destroyedVersion;
    void OnMouseDown() {
        // When the user clicks the object
        //Instantiate the 'cracked' version and destroy the original object
        Debug.Log("Destroy object here");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}

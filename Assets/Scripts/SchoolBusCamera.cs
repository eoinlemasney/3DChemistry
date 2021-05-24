
using UnityEngine;

public class SchoolBusCamera : MonoBehaviour
{
    public Camera mainCam;
    public Camera busCam;

    public void Start()
    {
        mainCam.enabled = true;
        busCam.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Player")
        {
            Debug.Log("Player");

            busCam.enabled = true;
            mainCam.enabled = false;
            PlayerController.enabledCamera = busCam;
            // detected = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        {
            Debug.Log("OnTriggerExit");
            mainCam.enabled = true;
            busCam.enabled = false;
            PlayerController.enabledCamera = mainCam;
            
        }
    }

}

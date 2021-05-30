
using UnityEngine;

public class Interactable : MonoBehaviour
{

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public float radius = 3f;
    public Transform interactionTransform;


    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }



    void Update() {
        if (isFocus  && !hasInteracted )
        {

            float distance = Vector3.Distance(player.position, transform.position);
            Debug.Log(distance);
            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }
    void OnDrawGizmosSelected() {

        if (interactionTransform == null){
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Onfocused (Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;

    }

    public void OnDefocused () {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
}


using UnityEngine;

public class Interactable : MonoBehaviour
{

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public float radius = 3f;


// fiinshed branckey episode 2 at 12:22

    void Update() {
        if (isFocus  && !hasInteracted )
        {
            float distance = Vector3.Distance(player.position, transform.position);
            Debug.Log(distance);
            if (distance <= radius) {
                Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
    }
    void OnDrawGizmosSelected() {
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

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/* Controls the player. Here we chose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Animator anim;

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;

    public Interactable focus;  // Our current focus: Item, Enemy etc.

    public LayerMask movementMask;      // The ground
    public LayerMask interactionMask;   // Everything we can interact with

    PlayerMotor motor;      // Reference to our motor
    Rigidbody rigidbody1;
    public static Camera cam;           // Reference to our camera
    public static Camera enabledCamera;

    // Get references
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        rigidbody1 = GetComponent<Rigidbody>();
        cam = Camera.main;
        enabledCamera = cam;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

		 if (transform.hasChanged)
         {
             anim.SetBool("isRunning", true);
             transform.hasChanged = false;
         }
         else
         {
             anim.SetBool("isRunning", false);
         }

        if (Input.GetMouseButtonDown(0))
        {
            if (ChemistryExperiment.hasItems)
                return;


            // Shoot out a ray
            Ray ray = enabledCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If we hit
            if (Physics.Raycast(ray, out hit, movementMask))
            {
                motor.MoveToPoint(hit.point);

                //stop focusing
                RemoveFocus();
            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = enabledCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                // If we hit it set it as the focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);

        }
        newFocus.Onfocused(transform);

    }


    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();

    }

    // Set our focus to a new focus
    // void SetFocus (Interactable newFocus)
    // {
    // 	if (onFocusChangedCallback != null)
    // 		onFocusChangedCallback.Invoke(newFocus);

    // 	// If our focus has changed
    // 	if (focus != newFocus && focus != null)
    // 	{
    // 		// Let our previous focus know that it's no longer being focused
    // 		// focus.OnDefocused();
    // 	}

    // 	// Set our focus to what we hit
    // 	// If it's not an interactable, simply set it to null
    // 	focus = newFocus;

    // 	if (focus != null)
    // 	{
    // 		// Let our focus know that it's being focused
    // 		// focus.OnFocused(transform);
    // 	}



}


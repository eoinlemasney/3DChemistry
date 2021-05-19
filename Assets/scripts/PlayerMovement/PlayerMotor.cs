using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	NavMeshAgent agent;		// Reference to our agent
    Transform target;

	// Get references
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        //This checks to see if we are hovering over the ui. If so, dont move
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (target != null) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }


	
	public void MoveToPoint (Vector3 point)
	{
		agent.SetDestination(point);
	}

	// Start following a target
    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .6f;
        agent.updateRotation = false;
        target = newTarget.transform;
    }


        public void StopFollowingTarget()
    {
        agent.updateRotation = true;
        target =null;
    }

void FaceTarget() {

Vector3 direction = (target.position - transform.position).normalized;
Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation.normalized, Time.deltaTime *5f);
}

}


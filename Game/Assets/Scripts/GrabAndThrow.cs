using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndThrow : MonoBehaviour {
 
    GameObject grabbedObject;

    float grabbedObjectSize;

    Vector3 previousGrabPosition;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position +Camera.main.transform.forward*range;
        if(Physics.Linecast(position,target,out raycastHit))
        
            return raycastHit.collider.gameObject;
        return null;

    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        grabbedObjectSize = gameObject.GetComponent<MeshRenderer>().bounds.size.magnitude;
        grabbedObject.GetComponent<Rigidbody>().useGravity = false;
    }
	
    void DropObject()
    {
        if (grabbedObject == null)
            return;

        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = throwVector.magnitude / Time.deltaTime;
            Vector3 throwVelocity = speed * throwVector.normalized;
            rb.velocity = throwVelocity;
            rb.useGravity = true;
        }
            
        grabbedObject = null;


    }

    bool CanGrab(GameObject candidate)
    {
        return candidate.GetComponent<Rigidbody>() != null;
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedObject == null)
            {
                TryGrabObject(GetMouseHoverObject(2));
              
            }
            else
            {
                DropObject();
            }
            if(grabbedObject != null)
            {
                previousGrabPosition = grabbedObject.transform.position;
                Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward*grabbedObjectSize;
                grabbedObject.transform.position = newPosition;
            }
        }
	}
}

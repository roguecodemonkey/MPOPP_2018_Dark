using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
	[SerializeField]
	float pickupDistance = 2;

	[SerializeField]
	Rigidbody carriedObject;

	[SerializeField]
	float floatDistance = 2;

	[SerializeField]
	float smooth = 12;

	[SerializeField]
	bool carrying;

	Camera mainCamera;

    private void Start()
    {
		mainCamera = Camera.main;
    }

    private void Update()
    {
        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();
        }
        else
        {
            Pickup();
        }
    }

    void Carry(Rigidbody o)
    {
		var pos = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * floatDistance, Time.deltaTime * smooth);
		Debug.DrawLine(pos, o.transform.position, Color.yellow);
		o.velocity = (pos - o.transform.position) / Time.deltaTime;
		o.transform.rotation = mainCamera.transform.rotation;
    }

    void Pickup()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray ray = mainCamera.ViewportPointToRay(Vector2.one * 0.5f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickupDistance))
            {
				var p = hit.collider;
				
				if (p.gameObject.layer != LayerMask.NameToLayer("Pickupable"))
					return;

                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.GetComponent<Rigidbody>();
					carriedObject.useGravity = false;
                }
            }
        }
    }

    void CheckDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        carrying = false;
		carriedObject.useGravity = true;
		carriedObject = null;
    }
}

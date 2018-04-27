using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Interactions;

public class InteractableEvent : UnityEvent<IInteractable> { }

public class InteractableDetector : MonoBehaviour
{
	[SerializeField]
	float maxDistance;

	[SerializeField]
	LayerMask raycasrMask;
	
	public InteractableEvent OnDetectionEnter;

	public InteractableEvent OnDetectionExit;

	IInteractable interactableObject;

	void Update()
	{
		RaycastHit hit;
		var ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

		if (Physics.Raycast(ray, out hit, maxDistance, raycasrMask))
		{
			var obj = hit.collider.GetComponent<IInteractable>();

			if (obj == interactableObject) return;

			if (interactableObject != null)
				OnDetectionExit?.Invoke(interactableObject);

			interactableObject = obj;
			if (interactableObject != null)
			{
				OnDetectionEnter?.Invoke(interactableObject);
			}
		}
	}
}

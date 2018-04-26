using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	public class PressPlate : MonoInteractable
	{
		[SerializeField]
		LayerMask affetcableLayer;

		[SerializeField]
		List<GameObject> pressingObjects;

		public override void StartInteracting() { }

		public override void StopInteracting() { }

		private void Interacting()
		{
			if (pressingObjects.Count > 0)
			{
				if (!isInteracting)
				{
					InvokeStartInteracting();
				}

				isActivated = true;
				isInteracting = true;

				InvokeKeepInteracting();
			}
			else
			{
				if (isInteracting)
				{
					InvokeStopInteracting();
				}

				isActivated = false;
				isInteracting = false;
			}
		}

		protected override void Update()
		{
			Interacting();
			if (isActivated)
			{
				InvokeActivated();
				onActivated?.Invoke();
			}
			else
			{
				InvokeDeactivated();
				onDeactivated?.Invoke();
			}
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (((1 << collider.gameObject.layer) & affetcableLayer) != 0)
			{
				pressingObjects.Add(collider.gameObject);
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			if (((1 << collider.gameObject.layer) & affetcableLayer) != 0)
			{
				pressingObjects.Remove(collider.gameObject);
			}
		}
	}
}

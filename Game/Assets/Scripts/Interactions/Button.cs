using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	public class Button : MonoInteractable
	{
		public override void StartInteracting()
		{
			if (!isInteracting)
			{
				InvokeStartInteracting();
				InvokeActivated();
				onActivated?.Invoke();
			}

			isActivated = true;
			isInteracting = true;
		}

		public override void StopInteracting()
		{
			if (isInteracting)
			{
				InvokeStopInteracting();
				InvokeDeactivated();
				onDeactivated?.Invoke();
			}

			isActivated = false;
			isInteracting = false;
		}
	}
}

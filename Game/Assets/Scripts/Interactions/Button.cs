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
			}

			isActivated = true;
			isInteracting = true;
		}

		public override void StopInteracting()
		{
			if (isInteracting)
			{
				InvokeStopInteracting();
			}

			isActivated = false;
			isInteracting = false;
		}
	}
}

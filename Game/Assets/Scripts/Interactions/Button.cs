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
				print("StartInteracting");
				InvokeStartInteracting();
			}

			isActivated = true;
			isInteracting = true;
		}

		public override void StopInteracting()
		{
			if (isInteracting)
			{
				print("StopInteracting");
				InvokeStopInteracting();
			}

			isActivated = false;
			isInteracting = false;
		}
	}
}

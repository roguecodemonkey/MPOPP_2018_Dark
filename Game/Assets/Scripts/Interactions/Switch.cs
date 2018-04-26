using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	public class Switch : MonoInteractable
	{
		public override void StartInteracting()
		{
			if (!isInteracting)
			{
				print("StartInteracting");
				InvokeStartInteracting();
			}

			isActivated = !isActivated;

			isInteracting = true;
		}

		public override void StopInteracting()
		{
			if (isInteracting)
			{
				print("StopInteracting");
				InvokeStopInteracting();
			}

			isInteracting = false;
		}
	}
}

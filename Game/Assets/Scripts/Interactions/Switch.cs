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
				InvokeStartInteracting();
			}

			isActivated = !isActivated;
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

			isInteracting = true;
		}

		public override void StopInteracting()
		{
			if (isInteracting)
			{
				InvokeStopInteracting();
			}

			isInteracting = false;
		}
    }
}

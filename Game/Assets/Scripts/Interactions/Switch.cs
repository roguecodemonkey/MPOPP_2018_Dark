using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	public class Switch : MonoBehaviour, IInteractable
	{
		[SerializeField]
		protected bool isInteracting;

		[SerializeField]
		protected bool isActivated;

		[SerializeField]
		protected UnityEvent onActivated;

		[SerializeField]
		protected UnityEvent onDeactivated;

		public virtual bool IsInteracting => isInteracting;
		public virtual bool IsActivated => isActivated;

		public virtual event Action OnStartInteracting;
		public virtual event Action OnKeepInteracting;
		public virtual event Action OnStopInteracting;

		public virtual event Action OnActivated;
		public virtual event Action OnDeactivated;

		public void StartInteracting()
		{
			if (!isInteracting)
			{
				OnStartInteracting?.Invoke();
			}

			isActivated = !isActivated;

			isInteracting = true;
		}

		public void StopInteracting()
		{
			if (isInteracting)
			{
				OnStopInteracting?.Invoke();
			}

			isInteracting = false;
		}

		protected virtual void Update()
		{
			if (isInteracting)
			{
				OnKeepInteracting?.Invoke();
			}

			if (isActivated)
			{
				OnActivated?.Invoke();
				onActivated?.Invoke();
			}
			else
			{
				OnDeactivated?.Invoke();
				onDeactivated?.Invoke();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
	public abstract class MonoInteractable : MonoBehaviour, IInteractable
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

		protected void InvokeStartInteracting()		{ OnStartInteracting?.Invoke(); }
		protected void InvokeKeepInteracting()		{ OnKeepInteracting?.Invoke(); }
		protected void InvokeStopInteracting()		{ OnStopInteracting?.Invoke(); }
		protected void InvokeActivated()			{ OnActivated?.Invoke(); }
		protected void InvokeDeactivated()			{ OnDeactivated?.Invoke(); }

		public abstract void StartInteracting();

		public abstract void StopInteracting();

		protected virtual void Update()
		{
			if (isInteracting)
			{
				InvokeKeepInteracting();
			}

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
	}
}

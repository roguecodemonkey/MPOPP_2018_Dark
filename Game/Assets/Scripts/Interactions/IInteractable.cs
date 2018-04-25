using System;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionMode
{
	Once, // Use one to trigger
	Hold, // Hold for certain time to trigger
}

public enum TriggeringMode
{
	Once, // Trigger once
	Switch, // Turn on or off. when on, keep triggering
	Timer, // Push once to turn on, turn off after certain time
}

public interface IInteractable
{
	event Action OnStartInteracting;
	event Action OnKeepInteracting;
	event Action OnStopInteracting;

	void Interact();
}

public abstract class MonoInteractableObject : MonoBehaviour, IInteractable
{
	public event Action OnStartInteracting;
	public event Action OnKeepInteracting;
	public event Action OnStopInteracting;

	public void Interact()
	{
		
	}
}
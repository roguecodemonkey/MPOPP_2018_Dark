using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IInteractable
{
	/// <summary>
	/// Wether this object is being interacting.
	/// </summary>
	bool IsInteracting { get; }

	/// <summary>
	/// Wether this object is Activated.
	/// </summary>
	bool IsActivated { get; }

	/// <summary>
	/// Calls when interaction start.
	/// </summary>
	event Action OnStartInteracting;

	/// <summary>
	/// Calls when interaction keep on.
	/// </summary>
	event Action OnKeepInteracting;

	/// <summary>
	/// Calls when interaction end.
	/// </summary>
	event Action OnStopInteracting;
	
	/// <summary>
	/// Keeps calling while this object is activated.
	/// </summary>
	event Action OnActivated;

	/// <summary>
	/// Keeps calling while this object is deactivated.
	/// </summary>
	event Action OnDeactivated;
	

	void StartInteracting();
	void StopInteracting();
}
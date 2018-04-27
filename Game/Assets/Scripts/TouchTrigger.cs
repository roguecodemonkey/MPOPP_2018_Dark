using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchTrigger : MonoBehaviour
{
	[SerializeField]
	bool triggerOnlyOnce;

	[SerializeField]
	string[] triggerableTags;

	[SerializeField]
	UnityEvent onTrigged;
	bool triggeed;

	void OnTriggerEnter(Collider collider)
	{
		if (!IsTriggerable(collider.tag)) return;

		triggeed = true;
		if (onTrigged != null)
		{
			onTrigged.Invoke();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (!IsTriggerable(collision.collider.tag)) return;

		triggeed = true;
		if (onTrigged != null)
		{
			onTrigged.Invoke();
		}
	}

	bool IsTriggerable(string tag)
	{
		if (triggeed && triggerOnlyOnce) return false;

		if (triggerableTags.Length == 0) return true;

		foreach(string s in triggerableTags)
		{
			if (s == tag) return true;
		}

		return false;
	}
}

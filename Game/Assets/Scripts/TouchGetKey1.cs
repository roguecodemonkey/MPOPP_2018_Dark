using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchGetKey1 : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnGotKey;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player" &&
			!GlobalSettings.GotFirstLevelKey) return;

		print("Got key one");
		GlobalSettings.GotFirstLevelKey = true;
		OnGotKey?.Invoke();
	}
}

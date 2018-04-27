using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchGetKey2 : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnGotKey;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player" && 
			!GlobalSettings.GotThirdLevelKey) return;

		print("Got key two");
		GlobalSettings.GotThirdLevelKey = true;
		OnGotKey?.Invoke();
	}
}

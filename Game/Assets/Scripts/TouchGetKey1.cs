using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGetKey1 : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;

		GlobalSettings.GotFirstLevelKey = true;
	}
}

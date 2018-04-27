using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitInFirstLevel : MonoBehaviour
{
	[SerializeField]
	Transform ResetPosition;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			GlobalSettings.Gameover();
			return;
		}

		if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
		{
			other.transform.position = ResetPosition.position;
			return;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Guard : MonoBehaviour
{
	[SerializeField]
	float viewRange;

	[SerializeField]
	float viewAngle;

	[SerializeField]
	UnityEvent OnPlayerDetected;

	Transform player;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward * viewRange);
		Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward * viewRange);
	}

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		if (!player)
			this.enabled = false;
	}

	private void Update()
	{
		var dir = player.position - this.transform.position;
		if (dir.sqrMagnitude > viewRange * viewRange)
			return;

		if (Mathf.Abs(Vector3.Angle(transform.forward, dir)) > viewAngle/2)
			return;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, dir, out hit))
		{
			if (hit.collider.transform != player) return;
		}

		OnPlayerDetected?.Invoke();
		print("Caught player");
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.transform == player)
		{
			OnPlayerDetected?.Invoke();
			print("Caught player");
		}
	}
}

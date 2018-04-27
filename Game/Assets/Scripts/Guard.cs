using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectMover))]
public class Guard : MonoBehaviour
{
	[SerializeField]
	float viewRange;

	[SerializeField]
	float viewAngle;

	[SerializeField]
	UnityEvent OnPlayerDetected;

	[SerializeField]
	Transform[] PatrolRoute;

	int currentPatrolPointIndex;

	Transform player;
	ObjectMover mover;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward * viewRange);
		Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward * viewRange);
	}

	private void Awake()
	{
		mover = GetComponent<ObjectMover>();
		if (PatrolRoute != null && PatrolRoute.Length > 0)
		{
			mover.OnChangeState += OnMoverStateChanged;
			mover.Target = PatrolRoute[0];
		}

		player = GameObject.FindGameObjectWithTag("Player").transform;
		if (!player)
			this.enabled = false;
	}

	private void Update()
	{
		LookingForPlayer();
	}

	private void LookingForPlayer()
	{
		var dir = player.position - this.transform.position;
		if (dir.sqrMagnitude > viewRange * viewRange)
			return;

		if (Mathf.Abs(Vector3.Angle(transform.forward, dir)) > viewAngle / 2)
			return;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, dir, out hit))
		{
			if (hit.collider.transform != player) return;
		}

		OnPlayerDetected?.Invoke();
		print("Caught player");
	}

	private void OnMoverStateChanged(ObjectMover mover)
	{
		if (mover.IsMoving) return;

		currentPatrolPointIndex++;
		currentPatrolPointIndex = currentPatrolPointIndex >= PatrolRoute.Length ? 0 : currentPatrolPointIndex;

		mover.Target = PatrolRoute[currentPatrolPointIndex];
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

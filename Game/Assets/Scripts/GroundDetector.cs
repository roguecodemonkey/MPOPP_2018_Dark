using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
	[SerializeField]
	LayerMask detectMask;

	[SerializeField]
	float detectDepth;

	[SerializeField]
	Vector3 detectOffset;

	public event Action<Collider> OnTouchGround;
	public event Action<Collider> OnStayGround;
	public event Action<Collider> OnLeaveGround;
	
	Collider lastGround;

	private void FixedUpdate()
	{
		Debug.DrawRay(transform.position + detectOffset, Vector3.down * detectDepth, Color.yellow);
		var originPoint = transform.position + detectOffset;
		RaycastHit hit;
		if (Physics.Raycast(originPoint, Vector3.down, out hit, detectDepth, detectMask.value))
		{
			if (!lastGround)
				OnTouchGround?.Invoke(hit.collider);

			lastGround = hit.collider;
			
			OnStayGround?.Invoke(hit.collider);
		}
		else
		{
			OnLeaveGround?.Invoke(lastGround);
			lastGround = null;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField, Range(0, 10)]
	float moveSpeed;

	[SerializeField]
	float jumpPower;

	[SerializeField]
	float crouchHeight;

	[SerializeField]
	float crouchSpeedMultiplier;

	bool isAirborne;
	bool isCrouching;

	private void Update ()
	{
		DetectGround();
		Jump();
		Crouch();
		MovePlayer();
    }

	private void MovePlayer()
	{
		Vector3 spaceMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (spaceMovement.sqrMagnitude > 1)
			spaceMovement.Normalize();

		transform.Translate(spaceMovement * moveSpeed * Time.deltaTime);
	}

	private void DetectGround()
	{

	}

	private void Jump()
	{

	}

	private void Crouch()
	{

	}
}


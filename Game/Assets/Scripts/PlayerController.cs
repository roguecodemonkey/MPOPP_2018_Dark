using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;
using Interactions;


[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InteractableDetector))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SonarFx))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	float moveSpeed;

	[SerializeField]
	float jumpPower;

	[SerializeField]
	float crouchHeight;

	[SerializeField]
	Transform cameraPivot;

	[SerializeField]
	float crouchSpeedMultiplier;

	[SerializeField]
	float sonarCooldown;

	GroundDetector ground;
	InteractableDetector interact;
	CapsuleCollider bodyCollider;
	new Rigidbody rigidbody;
	SonarFx sonar;

	Timer sonarTimer;

	bool isAirborne;
	bool isCrouching;

	float crouchPercentage;
	float origColliderHeight;
	Vector3 origColliderCenter;
	Vector3 origCameraPivotPos;

	IInteractable interactableObj;

	private void Awake()
	{
		ground = GetComponent<GroundDetector>();
		interact = GetComponent<InteractableDetector>();
		rigidbody = GetComponent<Rigidbody>();
		bodyCollider = GetComponent<CapsuleCollider>();
		sonar = GetComponent<SonarFx>();
		sonarTimer = new Timer();

<<<<<<< HEAD
		//interact.OnDetectionEnter.AddListener();
=======
		interact.OnDetectionEnter.AddListener(OnDetectionRaise);
		interact.OnDetectionExit.AddListener(OnDetectionQuit);
>>>>>>> ef2759264bd77759c0263c29e74e6db105aad8c3
		crouchPercentage = crouchHeight / bodyCollider.height;
		origColliderHeight = bodyCollider.height;
		origColliderCenter = bodyCollider.center;
		origCameraPivotPos = cameraPivot.localPosition;

		ground.OnTouchGround += _onTouchGround;
		ground.OnLeaveGround += _onLeaveGround;
	}

	private void Update()
	{
		Jump();
		Crouch();
		UseSonar();
		Interacting();
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	// TODO: move this function to another componenet.
	private void Interacting()
	{
		if (Input.GetButtonDown("Interact") && interactableObj != null)
		{
			interactableObj.StartInteracting();
		}

		if (Input.GetButtonUp("Interact") && interactableObj != null)
		{
			interactableObj.StopInteracting();
		}
	}

	private void UseSonar()
	{
		if (Input.GetButtonDown("Fire1") && sonarTimer.IsReachedTime())
		{
			sonarTimer.Start(sonarCooldown);
			sonar.StartSonar();
		}
	}

	private void OnDetectionRaise(IInteractable obj)
	{
		interactableObj = obj;
	}

	private void OnDetectionQuit(IInteractable obj)
	{
		interactableObj.StopInteracting();
		interactableObj = null;
	}


	private void MovePlayer()
	{
		Vector3 spaceMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (spaceMovement.sqrMagnitude > 1)
			spaceMovement.Normalize();

		var moveDir = spaceMovement * moveSpeed * Time.deltaTime;

		if (isCrouching)
			moveDir *= crouchSpeedMultiplier;
		moveDir = transform.TransformDirection(moveDir);

		rigidbody.MovePosition(transform.position + moveDir);
		//transform.Translate(moveDir);
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && !isAirborne)
		{
			rigidbody.AddForce(jumpPower * Vector3.up);
		}
	}

	private void Crouch()
	{
		var crouching = Input.GetButton("Crouch");
		if (crouching)
		{
			if (isCrouching) return;
			isCrouching = true;
			bodyCollider.height = origColliderHeight * crouchPercentage;
			bodyCollider.center = origColliderCenter * crouchPercentage;
			cameraPivot.localPosition = origCameraPivotPos * crouchPercentage;
		}
		else
		{
			if (!isCrouching) return;
			isCrouching = false;
			bodyCollider.height = origColliderHeight;
			bodyCollider.center = origColliderCenter;
			cameraPivot.localPosition = origCameraPivotPos;
		}
	}

	private void _onTouchGround(Collider collider)
	{
		isAirborne = false;
	}

	private void _onLeaveGround(Collider collider)
	{
		isAirborne = true;
	}
}

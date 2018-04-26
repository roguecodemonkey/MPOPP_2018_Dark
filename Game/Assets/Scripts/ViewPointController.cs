using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementWar
{
	public class ViewPointController : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		Transform cameraPivot;

		[SerializeField, Range(0, 10)]
		float turnSpeed;

		[SerializeField]
		float turnSmoothing;

		[SerializeField, Range(0, 10)]
		float tiltSpeed;

		[SerializeField]
		float tiltSmoothing;

		[SerializeField]
		float tiltMax;

		[SerializeField]
		float tiltMin;

		[SerializeField]
		float defaultFov;

		[SerializeField]
		float zoomFov;

		[SerializeField]
		float zoomInSpeed;

		[SerializeField]
		float zoomInMouseSpeedMultiplier;

		[SerializeField]
		bool lockCursor;

		[SerializeField]
		bool frozen;

		float lookAngle;
		float tiltAngle;

		bool aiming;

		#endregion

		#region Properties

		/// <summary>
		/// Stop the view point from moving
		/// </summary>
		public bool Frozen
		{
			get { return frozen; }
			set { frozen = value; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Moving the camera around a few specific axes
		/// </summary>
		void MoveCamera()
		{
			if (frozen) return;
			Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

			if (mouseMovement.sqrMagnitude > 1)
				mouseMovement.Normalize();

			mouseMovement.Scale(new Vector2(turnSpeed, tiltSpeed));

			if (aiming)
				mouseMovement *= zoomInMouseSpeedMultiplier;

			RotateXAxis(mouseMovement.y);
			RotateYAxis(mouseMovement.x);
		}

		/// <summary>
		/// Turning the camera around.
		/// </summary>
		void RotateYAxis(float turn)
		{
			lookAngle += turn;
			var targetRotation = Quaternion.Euler(0, lookAngle, 0);
			if (turnSmoothing > 0)
				transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, turnSmoothing * Time.deltaTime);
			else
				transform.localRotation = targetRotation;
		}

		/// <summary>
		/// Tilting the camera up and down.
		/// </summary>
		void RotateXAxis(float tilt)
		{
			tiltAngle -= tilt;
			if (tiltAngle > tiltMax) tiltAngle = tiltMax;
			if (tiltAngle < tiltMin) tiltAngle = tiltMin;

			var targetRotation = Quaternion.Euler(tiltAngle, 0, 0);
			if (tiltSmoothing > 0)
				cameraPivot.localRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, tiltSmoothing * Time.deltaTime);
			else
				cameraPivot.localRotation = targetRotation;
		}

		#endregion

		#region Unity messages

		void Awake()
		{
			if (cameraPivot) return;
			Debug.LogWarning(name + ": Haven't assiged camera pivot!!! This ViewPointController will be disabled.");
			enabled = false;
		}

		void Update()
		{
			// Temporary
			if (Input.GetKeyDown(KeyCode.K))
				lockCursor = !lockCursor;

			Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
			Cursor.visible = !lockCursor;

			MoveCamera();
		}

		#endregion
		
	}
}


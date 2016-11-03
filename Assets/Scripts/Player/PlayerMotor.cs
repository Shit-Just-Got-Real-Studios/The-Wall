﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotation = 0f;
	private float currentCamRotation = 0f;
	private Vector3 thrusterForce = Vector3.zero;

	[SerializeField]
	private float currentCamRotationLimit = 85f;
	[SerializeField]
	private Camera cam;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		Physics.gravity *= 3f;

	}

	public void Move (Vector3 _velocity) {
		velocity = _velocity;
	}

	public void Rotate (Vector3 _rotation) {
		rotation = _rotation;
	}

	public void CameraRotate (float _rotation) {
		cameraRotation = _rotation;
	}

	public void ApplyThruster(Vector3 _thrusterForce) {
		thrusterForce = _thrusterForce;
	}

	void FixedUpdate () {
		PerformMovement ();
		PerformRotation ();
	}

	void PerformMovement () {
		if (velocity != Vector3.zero) {
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}

		if (thrusterForce != Vector3.zero) {
			rb.AddForce (thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}

	void PerformRotation () {
		if (rotation != Vector3.zero) {
			rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		}
		if (cam != null ) {
			currentCamRotation -= cameraRotation;
			currentCamRotation = Mathf.Clamp (currentCamRotation, -currentCamRotationLimit, currentCamRotationLimit);
			cam.transform.localEulerAngles = new Vector3 (currentCamRotation, 0f, 0f);
		}
	}
}

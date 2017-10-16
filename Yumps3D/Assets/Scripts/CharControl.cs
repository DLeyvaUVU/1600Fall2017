using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {
	public CharacterController characterController;
	public float gravity = 9.81f;
	public Vector3 moveVector3;
	public float speed = 10;
	public float jumpForce = 100;
	void Start () {
		
	}

	void FixedUpdate () {
		moveVector3.y -= gravity * Time.deltaTime;
		if (characterController.isGrounded) {
			moveVector3.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			if (Input.GetKey(KeyCode.Space)) {
				moveVector3.y += jumpForce*Time.deltaTime;
			}
		}
		characterController.Move(moveVector3);
	}
}

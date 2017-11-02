using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour {
	public CharacterController characterController;
	public GameObject endScreen;
	public float gravity = 2.5f;
	public Vector3 moveVector3;
	public float speed = 10;
	public float jumpForce = 50;
	public static float health = 50;
	public GameObject HealthBar;
	void Start () {
		print(health);
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag){
			case "hazard":
				if ((CharControl.health - 15)> 0) {
					CharControl.health -= 15;
					HealthBar.SendMessage("ApplyDamage");
				} else {
					CharControl.health = 0;
					HealthBar.SendMessage("ApplyDamage");
					endScreen.SetActive(true);
				}
				break;
			default:
				break;
		}
	}
	void Update () {
		moveVector3.y -= gravity * Time.deltaTime;
		if (characterController.isGrounded) {
			moveVector3.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			if (Input.GetKeyDown("space")) {
				moveVector3.y = jumpForce*Time.deltaTime;
			}
		}
		characterController.Move(moveVector3);
	}
}

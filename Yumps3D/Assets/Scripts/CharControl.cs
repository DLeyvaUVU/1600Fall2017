using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour {
	public CharacterController characterController;
	public GameObject endScreen;
	public float gravity;
	public Vector3 move;
	public Vector3 moveTimed;
	public float speed;
	public float jumpForce;
	public static float health = 100;
	public GameObject HealthBar;
	void Start () {
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag){
			case "hazard":
				if ((CharControl.health - 15)> 0) {
					CharControl.health -= 15;
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health = 0;
					HealthBar.BroadcastMessage("ApplyDamage");
					endScreen.SetActive(true);
				}
				break;
			case "powerup":
				if (100 < (CharControl.health + 15)) {
					CharControl.health = 100;
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health += 15;
					HealthBar.BroadcastMessage("ApplyDamage");
				}
				break;
			default:
				break;
		}
	}
	void Update () {
		move.x = Input.GetAxis("Horizontal") * speed;
		if (characterController.isGrounded) {
			if (Input.GetKeyDown("space")) {
				move.y = jumpForce;
			}
			
		} else {
			move.y -= gravity * Time.deltaTime;
		}
		moveTimed.x = move.x*Time.deltaTime;
		moveTimed.y = move.y*Time.deltaTime;
		characterController.Move(moveTimed);
	}
}

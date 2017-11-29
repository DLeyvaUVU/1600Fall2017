﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour {
	public CharacterController characterController;
	public GameObject endScreen;
	public ParticleSystem burstEffect;
	public float gravity;
	public Vector3 move;//movement in units per second
	public Vector3 moveTimed;//movement with frametiming applied for framerate independence
	public float speed;
	public float jumpForce;
	public int burstNum;
	public static float health = 100;//global variable for the player's health
	public static int TotalCoins;
	public Text CoinUI;
	public GameObject HealthBar;
	public static bool playerActive = true;
	void Start () {
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag){ //looks at the tag of the other object
			case "hazard":
				if ((CharControl.health - 15)> 0) {//decrease health of player by 15 without going below zero
					CharControl.health -= 15; 
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health = 0;
					HealthBar.BroadcastMessage("ApplyDamage");
					CharControl.playerActive = false;
					endScreen.SetActive(true);
				}
				break;
			case "powerup":
				if (100 < (CharControl.health + 15)) {//increase health of player by 15 without going above 100
					CharControl.health = 100;
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health += 15;
					HealthBar.BroadcastMessage("ApplyDamage");
				}
				break;
			case "checkpoint":
				ReplayGame.startPosition = other.transform.position;//sets checkpoint
				break;
			case "coin":
				TotalCoins = int.Parse(CoinUI.text);//gets current amount of coins
				StartCoroutine(collectCoin());
				other.gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}
	IEnumerator collectCoin () {
		int newCoins = TotalCoins + 10;
		while (TotalCoins < newCoins) {
			TotalCoins++;
			CoinUI.text = TotalCoins.ToString();
			yield return 0;
		}
	}
	void Update () {
		if (playerActive) {
			move.x = Input.GetAxis("Horizontal") * speed;
			if (characterController.isGrounded) {
				if (Input.GetKeyDown("space")) {
					move.y = jumpForce;//only jumps if on the ground
				}

			} else {
				if (Input.GetKeyDown("space")&&(burstNum>0)) {
					move.y = jumpForce;
					burstNum--;
				}
				if (move.y > -50) {//checks for terminal velocity
					move.y -= gravity * Time.deltaTime;//only applies gravity off the ground
				} else {
					move.y = -50;//applies terminal velocity
				}
			}
			moveTimed.x = move.x*Time.deltaTime;//deltaTime is applied seperately so modifiers are easily implemented
			moveTimed.y = move.y*Time.deltaTime;
			characterController.Move(moveTimed);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifiers : MonoBehaviour {
	public GameObject HealthBar, endScreen;
	public int hpMod;
	public enum ModType {
		goal,
		quickDeath,
		hpUp,
		hpDown
	}
	public ModType powerUp;
	void OnTriggerEnter(Collider other)
	{
		switch (powerUp) {
			case ModType.hpUp:
				if (100 < (CharControl.health + hpMod)) {//increase health of player by 15 without going above 100
					CharControl.health = 100;
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health += hpMod;
					HealthBar.BroadcastMessage("ApplyDamage");
				}
				break;
			case ModType.hpDown:
				if ((CharControl.health - hpMod)> 0) {//decrease health of player by 15 without going below zero
					CharControl.health -= hpMod; 
					HealthBar.BroadcastMessage("ApplyDamage");
				} else {
					CharControl.health = 0;
					HealthBar.BroadcastMessage("ApplyDamage");
					CharControl.playerActive = false;
					endScreen.SetActive(true);
				}
				break;
			case ModType.quickDeath:
				break;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

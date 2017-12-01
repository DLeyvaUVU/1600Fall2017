using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifiers : MonoBehaviour {
	public GameObject HealthBar, endScreen;
	public Transform player;
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
				hpInc();
				break;
			case ModType.hpDown:
				hpDec();
				break;
			case ModType.quickDeath:
				hpDec();
				player.position = ReplayGame.startPosition;
				player.Translate(0,10,0);
				break;
		}
	}
	void hpInc () {
		if (100 < (CharControl.health + hpMod)) {//increase health of player by 15 without going above 100
			CharControl.health = 100;
			HealthBar.BroadcastMessage("ApplyDamage");
		} else {
			CharControl.health += hpMod;
			HealthBar.BroadcastMessage("ApplyDamage");
		}
	}
	void hpDec () {
		if ((CharControl.health - hpMod)> 0) {//decrease health of player by 15 without going below zero
			CharControl.health -= hpMod; 
			HealthBar.BroadcastMessage("ApplyDamage");
		} else {
			CharControl.health = 0;
			HealthBar.BroadcastMessage("ApplyDamage");
			CharControl.playerActive = false;
			endScreen.SetActive(true);
		}
	}
}

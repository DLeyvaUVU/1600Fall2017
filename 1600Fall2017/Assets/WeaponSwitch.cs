using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	public List<GameObject> weapons;
	void OnTriggerEnter(Collider _weapon)
	{
		weapons.Add(_weapon.gameObject);
	}
	public void MyWeaponSwitch (int i){
		switch (weapons[i].name){
			case "Missile":
				print("Missile");
				break;
			case "Plasma":
				print("Plasma");
				break;
			default:
				print("You have unrecognized alien technology");
				break;
		}
	}
}

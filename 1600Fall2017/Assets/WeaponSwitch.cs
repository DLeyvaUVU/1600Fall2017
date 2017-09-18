using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
	public string[] weapons;//[]Makes an array

	public void MyWeaponSwitch (int i){
		switch (weapons[i]){
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

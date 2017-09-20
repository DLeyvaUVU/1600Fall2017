using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {
	public string[] pickups;
	public bool canPlay = true;
	void Start (){
		foreach (var item in pickups) {
			print("I found a " + item + " pickup!");
		}
	}
	void Update()
	{
		if (canPlay) {
			print("Playing Game.");
		} else {
			print("Game Over");
		}
	}
}

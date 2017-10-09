using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aminal : MonoBehaviour {
	public int age;
	// Use this for initialization
	public virtual void Start () {
		exist();
	}

	void exist () {
		print(this.name + " came into existence.");
	}
	public void die () {
		print(this.name + " Died");
	}
	void eat (string food, int amount) {
		print(this.name + " ate " + amount + " " + food);
	}
	void sleep () {
		print(this.name + " Slept");
	}
	// Update is called once per frame
	void Update () {
		if (age < 1000) {
			age++;
		} else {
			age = 0;
			exist();
		}
		switch (age) {
			case 300:
				eat("bananas", 10);
				break;
			case 600:
				sleep();
				break;
			case 900:
				die();
				break;
		}
	}
}

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
	void die () {
		print(this.name + " Died");
	}
	void eat () {
		print(this.name + " Ate");
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
				eat();
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

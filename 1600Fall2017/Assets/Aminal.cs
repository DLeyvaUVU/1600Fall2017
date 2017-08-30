using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aminal : MonoBehaviour {

	// Use this for initialization
	public virtual void Start () {
		eat();
		sleep();
		die();
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
		
	}
}

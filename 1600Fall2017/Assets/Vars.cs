<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : Aminal {
	public float health = 100;
	// Use this for initialization
	public override void Start () {
		health = 200;
	}
	
=======
﻿using UnityEngine;
public class Vars : MonoBehaviour {
	public float health = 100;
>>>>>>> master
	void OnTriggerEnter()
	{
		health += 20;
	}
<<<<<<< HEAD
	// Update is called once per frame
	void Update () {
		if (health > 0) {
			health -= 0.1f;
		} else {
			die();
		}
	}
}
=======
}
>>>>>>> master

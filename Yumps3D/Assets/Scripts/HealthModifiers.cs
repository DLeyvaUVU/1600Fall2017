using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifiers : MonoBehaviour {
	public GameObject HealthBar, endScreen;
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
				break;
			case ModType.hpDown:
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

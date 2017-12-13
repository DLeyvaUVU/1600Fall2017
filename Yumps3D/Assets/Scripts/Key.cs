using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public GameObject door;
	void OnTriggerEnter()
	{
		door.SetActive(false);
		gameObject.SetActive(false);
	}
}

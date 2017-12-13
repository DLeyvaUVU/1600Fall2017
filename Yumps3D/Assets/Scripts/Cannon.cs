using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public GameObject missile, missileControl;
	float counter;
	void OnTriggerStay(Collider other)
	{
		counter += Time.deltaTime;
		if (counter > 2) {
			Vector3 Spawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y);
			GameObject Clone= Instantiate(missileControl, Spawn, Quaternion.identity);
			Clone.SetActive(true);
			Spawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			GameObject Clone2 = Instantiate(missile, Spawn, Quaternion.identity);
			Clone2.SetActive(true);
			Clone2.SendMessage("SetCounterpart", Clone.transform);
			counter = 0;
		}
	}
	void OnTriggerExit(Collider other)
	{
		counter = 0;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYflip : MonoBehaviour {
	Transform counterpart;
	public bool fullTransform;
	void SetCounterpart (Transform other) {
		counterpart = other;
	}
	void OnTriggerEnter()
	{
		Destroy(counterpart.gameObject);
		Destroy(gameObject);
	}
	void Update () {
		if (fullTransform) {
			gameObject.transform.position = new Vector3(counterpart.position.x, counterpart.position.z, counterpart.position.y);
			gameObject.transform.rotation = counterpart.rotation;
			gameObject.transform.Rotate(new Vector3(-90, 0, 0), Space.World);
		} else {
			gameObject.transform.position = new Vector3(counterpart.position.x, counterpart.position.z, counterpart.position.y);
		}
	}
}

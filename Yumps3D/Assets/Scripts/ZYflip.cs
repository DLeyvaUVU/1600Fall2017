using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYflip : MonoBehaviour {
	public Transform counterpart;
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(counterpart.position.x, counterpart.position.z, counterpart.position.y);
	}
}

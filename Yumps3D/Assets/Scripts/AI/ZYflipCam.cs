using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYflipCam : MonoBehaviour {
	public Transform vert, hori;
	// Update is called once per frame
	void Update () {
			gameObject.transform.position = new Vector3(hori.position.x, vert.position.z, vert.position.y);
	}
}

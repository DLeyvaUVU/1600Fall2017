using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {//calculated after physics every frame
		transform.position = player.transform.position + offset;
	}
}

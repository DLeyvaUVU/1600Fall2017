using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	void Update () {
		gameObject.transform.Rotate(0, 30*Time.deltaTime, 0);	
	}
}

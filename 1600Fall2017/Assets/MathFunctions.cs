using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		myScore = returnZero ();
		print(CheckPassword(myPassword));
		myPassword.
	}
	public int myScore = 100;
	public string myPassword; 
	int returnZero () {
		return 0;
	}
	string CheckPassword (string _login) {
		if (_login == "ou812") {
			return "password";
		} else {
			return "incorrect";
		}
	}
	
	// Update is called once per frame
}

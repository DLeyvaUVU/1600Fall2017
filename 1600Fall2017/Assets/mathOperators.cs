using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mathOperators : MonoBehaviour {

	public float num1, num2, addResult, subResult, multResult, divideResult, remainderResult;
	// Update is called once per frame
	void Update () {
		addResult = num1 + num2;
		subResult = num1 - num2;
		multResult = num1 * num2;
		if (num2 != 0) {
			divideResult = num1/num2;
		} else {
			print("Can't divide by Zero.");
		}
		remainderResult = num1 % num2;
	}
}

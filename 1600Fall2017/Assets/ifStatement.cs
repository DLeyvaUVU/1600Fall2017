﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ifStatement : MonoBehaviour {

	public int num1;
	public int num2;
	public int value;
	public bool canPlay;
	public Text input;
	private string password = "1337G@m3r";

	void Start()
	{
		if (num1 + num2 == value)
		{
			print(value);
		}
		if (canPlay)
		{
			print("Play");
		}
	}
	
	void Update()
	{
		if (input.text == password) {
			print("GJ, nerd, you know the password. Are you happy now?");
			canPlay = true;
		} else {
			print("git gud");
			canPlay = false;
		}
		if (canPlay) {
			print("Playing Game...");
		} else {
			print("git gud, play when you know the right password");
		}
	}
}

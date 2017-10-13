using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCheckPoint : MonoBehaviour {
	public GameObject player;
	Vector3 checkPoint;
	string[] playerPrefsTitles = {"CheckPointX", "CheckPointY", "CheckPointZ"};
	void Start()
	{
		for (int i = 0; i < playerPrefsTitles.Length; i++)
		{
			checkPoint[i] = PlayerPrefs.GetFloat(playerPrefsTitles[i], checkPoint[i]);
		}
		player.transform.position = checkPoint;
	}
	void OnTriggerEnter()
	{
		checkPoint = transform.position;
		for (int i = 0; i < playerPrefsTitles.Length; i++)
		{
			PlayerPrefs.SetFloat(playerPrefsTitles[i], checkPoint[i]);
		}
	}
}

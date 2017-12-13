using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour {
	public Transform player;
	public Image uiBar;
	public GameObject GameOverUI;
	public static Vector3 startPosition;
	public static bool GameEnd;
	void Awake()
	{
		startPosition = player.position;
		GameOverUI.SetActive(false);
	}
	public void Click () {
		if (GameEnd) {
			var Scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(Scene.name);
		} else {
			CharControl.health = 100;
			CharControl.playerActive = true;
			player.position = startPosition;
			uiBar.BroadcastMessage("ApplyDamage");
			GameOverUI.SetActive(false);
		}
	}
}

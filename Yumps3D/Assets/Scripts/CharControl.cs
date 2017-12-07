using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour {
	public CharacterController characterController;
	public GameObject endScreen;
	public ParticleSystem burstEffect;
	public float gravity;
	public Vector3 move;//movement in units per second
	public Vector3 moveTimed;//movement with frametiming applied for framerate independence
	public float speed;
	public float jumpForce;
	public static int burstNum = 50;
	public static float health = 100;//global variable for the player's health
	public static int TotalCoins;
	public Text CoinUI;
	public GameObject HealthBar;
	public static bool playerActive = true;
	void Start () {
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag){ //looks at the tag of the other object
			case "checkpoint":
				ReplayGame.startPosition = other.transform.position;//sets checkpoint
				break;
			case "coin":
				TotalCoins = int.Parse(CoinUI.text);//gets current amount of coins
				StartCoroutine(collectCoin());
				other.gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}
	IEnumerator collectCoin () {
		int newCoins = TotalCoins + 10;
		while (TotalCoins < newCoins) {
			TotalCoins++;
			CoinUI.text = TotalCoins.ToString();
			yield return 0;
		}
	}
	void Update () {
		if (playerActive) {
			move.x = Input.GetAxis("Horizontal") * speed;
			if (characterController.isGrounded) {
				if (burstEffect.isPlaying) {
					burstEffect.Stop();
				}
				if (Input.GetKeyDown("space")) {
					move.y = jumpForce;//only jumps if on the ground
				}

			} else {
				if (Input.GetKeyDown("space")&&(burstNum>0)) {
					move.y = jumpForce;
					burstNum--;	
					var emitParams = new ParticleSystem.EmitParams();
					var main = burstEffect.main;
					main.startSpeed = 5;
					burstEffect.Emit(30);
					main.startSpeed = 1;
					burstEffect.Play();
				}
				if (move.y > -50) {//checks for terminal velocity
					move.y -= gravity * Time.deltaTime;//only applies gravity off the ground
				} else {
					move.y = -50;//applies terminal velocity
				}
			}
			moveTimed.x = move.x*Time.deltaTime;//deltaTime is applied seperately so modifiers are easily implemented
			moveTimed.y = move.y*Time.deltaTime;
			characterController.Move(moveTimed);
		}
	}
}

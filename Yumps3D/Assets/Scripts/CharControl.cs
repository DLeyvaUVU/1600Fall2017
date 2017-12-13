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
	public static int burstNum = 0;
	public static float health = 100;//global variable for the player's health
	public Text BurstUI;
	public GameObject HealthBar;
	public static bool playerActive = true;
	public static List<GameObject> ResetObjects = new List<GameObject>();
	void Start () {
		BurstUI.text = burstNum.ToString();
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag){ //looks at the tag of the other object
			case "checkpoint":
				ReplayGame.BurstReset= burstNum;
				ReplayGame.startPosition = other.transform.position;//sets checkpoint
				ResetObjects.Clear();
				other.gameObject.SetActive(false);
				break;
			case "burstUP":
				burstNum++;
				BurstUI.text = burstNum.ToString();
				ResetObjects.Add(other.gameObject);
				other.gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}
	void ResetPlayer () {
		foreach (GameObject Object in CharControl.ResetObjects) {
			Object.SetActive(true);
		}
		transform.position = ReplayGame.startPosition;
		burstNum = ReplayGame.BurstReset;
		BurstUI.text = burstNum.ToString();
	}
	void Update () {
		if (playerActive) {
			if ((characterController.collisionFlags & CollisionFlags.Above) != 0) {
				move.y = 0;
			}
			move.x = Input.GetAxis("Horizontal") * speed;
			if (characterController.isGrounded) {
				move.y = -1;
				if (burstEffect.isPlaying) {
					burstEffect.Stop();
				}
				if (Input.GetKeyDown("space")) {
					move.y = jumpForce;//only jumps if on the ground
				}

			} else {
				if (move.y > -40) {//checks for terminal velocity
					move.y -= gravity * Time.deltaTime;//only applies gravity off the ground
				} else {
					move.y = -40;//applies terminal velocity
				}
				if (Input.GetKeyDown("space")&&(burstNum>0)) {
					move.y = jumpForce;
					burstNum--;	
					BurstUI.text = burstNum.ToString();
					var emitParams = new ParticleSystem.EmitParams();
					emitParams.startSize = 1;
					var main = burstEffect.main;
					main.startSpeed = 5;
					burstEffect.Emit(emitParams, 30);
					main.startSpeed = 1;
					burstEffect.Play();
				}
			}
			moveTimed.x = move.x*Time.deltaTime;//deltaTime is applied seperately so modifiers are easily implemented
			moveTimed.y = move.y*Time.deltaTime;
			characterController.Move(moveTimed);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			ResetPlayer();
		}
	}
}

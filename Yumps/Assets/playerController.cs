using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	private Rigidbody2D RB;
	public float jump;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveH = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown("space")) {
			//jump = 500.0f;
			RB.velocity = new Vector2 (RB.velocity.x, 10);
		}	else {
			//jump = 0.0f;
		}
		Vector2 movement = new Vector2 (moveH*15, 0);
		RB.AddForce (movement);
		if (Mathf.Abs(RB.velocity.x)>5) {
			RB.velocity = new Vector2 (Mathf.Sign(RB.velocity.x)*5, RB.velocity.y);
		}
	}
}

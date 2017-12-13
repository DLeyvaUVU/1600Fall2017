using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissileAI : MonoBehaviour {
	public Transform player;
	public float dist;
	public float speedSet;
	public NavMeshAgent agent;
	void OnCollisionEnter()
	{
		gameObject.SetActive(false);
	}
	void Update () {
		agent.ResetPath();
		agent.destination = new Vector3(player.position.x, player.position.z, player.position.y);
		if (agent.pathPending) {
			dist = Vector3.Distance(transform.position, new Vector3(player.position.x, player.position.z,player.position.y));
		} else {
			dist = agent.remainingDistance;
		}
		speedSet = Mathf.Pow(dist/2, 2) + 1;
		if (speedSet > 200) {
			agent.speed = 200;
		} else {
			agent.speed = speedSet;
		}
	}
}

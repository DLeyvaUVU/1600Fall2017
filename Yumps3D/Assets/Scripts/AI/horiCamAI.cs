using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class horiCamAI : MonoBehaviour {
	public Transform player;
	public float dist;
	public float speedSet;
	public NavMeshAgent agent;
	void Update () {
		agent.ResetPath();
		agent.destination = new Vector3(player.position.x, player.position.z, 0);
		if (agent.pathPending) {
			dist = Vector3.Distance(transform.position, new Vector3(player.position.x, player.position.z,0));
		} else {
			dist = agent.remainingDistance;
		}
		speedSet = dist*4 + 1;
		if (speedSet > 200) {
			agent.speed = 200;
		} else {
			agent.speed = speedSet;
		}
	}
}
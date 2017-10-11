using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public NavMeshAgent agent;
	public Transform player;
	void Update () {
		agent.destination = player.position;
	}
	public void Stun (float _speed) {
		agent.speed = _speed;
	}
}

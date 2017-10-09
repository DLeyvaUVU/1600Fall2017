using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeAndAccess : MonoBehaviour {
	private int health = 100;
	public float score = 100;//public can't be used in a function only in the class
	public int checkHealth () {
		return health;
	}
	 int getEnemiesKilled () {
			return 13;
		}
	 float getScoreModifier () {
		int a = checkHealth();
		int b = getEnemiesKilled();
		float c = 1;
		if (b>5) {
			c=1.3f;
		}
		return c;
	}
	void Update()
	{
 
		score = getNewScore();

	}
	float getNewScore() {
			int a = getEnemiesKilled();
			float b = a*getScoreModifier();
			return b;
		}
}

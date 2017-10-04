using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeAndAccess : MonoBehaviour {
	private int health = 100;
	public int score = 100;//public can't be used in a function only in the class
	public int checkHealth () {
		return health;
	}
	void Update()
	{
		int getEnemiesKilled () {
			return 13;
		}
		float getScoreModifier () {
			int a = checkHealth();
			int b = getEnemiesKilled();
			float c;
			if (b>5) {
				c=1.3f;
			}
			return c;
		}
		int getNewScore() {
			int a = getEnemiesKilled();
			int b = 
			return b;
		}//can only be used in this function 
		score = getNewScore();

	}
}

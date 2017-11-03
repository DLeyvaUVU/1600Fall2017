using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbar : MonoBehaviour {
	public Image bar;
	public Color barColor;
	public float barSpeed;

	// Use this for initialization
	void Start () {
		StartCoroutine(UpdateBar());
	}
	void ApplyDamage () {
		StopAllCoroutines();
		StartCoroutine(UpdateBar());
	}
	void Update()
	{
		bar.color = barColor;
	}
	
	IEnumerator UpdateBar () {
		float fillStart = bar.fillAmount;
		float healthPercent = CharControl.health/100;
		float diffSign = Mathf.Sign(healthPercent - fillStart);
		while (!(healthPercent == bar.fillAmount)) {
			bar.fillAmount += barSpeed*diffSign*Time.deltaTime;
			if (bar.fillAmount > 0.5f) {
				barColor.r = ((1-bar.fillAmount)*2)*0.839f;
				barColor.g = 0.839f;
			} else {
				barColor.r = 0.839f;
				barColor.g = bar.fillAmount*2*0.839f;
			}
			if (diffSign == 0) {
				bar.fillAmount = healthPercent;
			}
			if ((diffSign > 0)&&(bar.fillAmount > healthPercent)) {
				bar.fillAmount = healthPercent;
			} else {
				if ((diffSign < 0)&&(bar.fillAmount < healthPercent)) {
					bar.fillAmount = healthPercent;
				}
			}
			yield return 0;
		}
		
	}
}

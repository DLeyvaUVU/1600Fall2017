using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbar : MonoBehaviour {
	public Image bar;
	public Color barColor;
	public float barTime = 0.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(UpdateBar());
	}
	void Update()
	{
		bar.color = barColor;
	}
	
	IEnumerator UpdateBar () {
		while (bar.fillAmount > 0) {
			bar.fillAmount -= barTime/10;
			if (bar.fillAmount > 0.5f) {
				barColor.r = ((1-bar.fillAmount)*2)*0.839f;
			} else {
				barColor.r = 0.839f;
				barColor.g = bar.fillAmount*2*0.839f;
			}
			yield return new WaitForSeconds(barTime);
		}
	}
}

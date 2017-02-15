﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour {
	public float increaseAmount = 0.1f;
	public Slider heatSlider;

	static Slider timerSlider;
	static bool lose;

	// Use this for initialization
	void Start () {
		timerSlider = GetComponent<Slider> ();

	}
	
	// Update is called once per frame
	void Update () {

		if(timerSlider.value >= 1) {
			GameOver.WinGame();
			this.enabled = false;
			heatSlider.enabled = false;
			Time.timeScale = 0;
		}

		timerSlider.value = timerSlider.value + increaseAmount * Time.deltaTime;
		
	}
}

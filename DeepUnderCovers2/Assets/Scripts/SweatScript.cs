﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SweatScript : MonoBehaviour {

	public Slider heatSlider;

	public Animator anim;


	public float AnimatorSliderValue
	{
		get {
			return anim.GetFloat (0);
		}

		set {
			anim.SetFloat ("HeatSliderValue", value);
		}
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorSliderValue = heatSlider.value;

	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatControlScript : MonoBehaviour {

	public float rateOfIncrease = 0.1f;
	public float decreaseValue = 0.2f;


	public Slider timerSlider;
	static Slider heatSlider;
	static bool HeatControlwin;


	// Use this for initialization
	void Start () {
		heatSlider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(heatSlider.value >= 1) {
			GameOver.LoseGame();
			this.enabled = false;
			Time.timeScale = 0;
		}
		if (Input.GetButton ("Fire1")) {
			heatSlider.value = heatSlider.value - decreaseValue * Time.deltaTime;

		} 
			else {
			heatSlider.value = heatSlider.value + rateOfIncrease * Time.deltaTime;
		}
	}
}

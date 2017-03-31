using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatControlScript : MonoBehaviour {

	static Slider heatSlider;


	// Use this for initialization
	void Start () {
		heatSlider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(heatSlider.value >= 1) {
			GameOver.LoseGame();
		}

	}
	public static void DecreaseSlider(float decreaseValue)
	{
		heatSlider.value -= decreaseValue;
	}

	public static void IncreaseSlider(float increaseValue)
	{
		heatSlider.value += increaseValue;
	}
}

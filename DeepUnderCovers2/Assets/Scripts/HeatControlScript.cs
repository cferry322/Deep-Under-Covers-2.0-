using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatControlScript : MonoBehaviour {

	static Slider heatSlider;
	public GameObject gameController;
	private bool lost;


	// Use this for initialization
	void Start () {
		lost = false;
		heatSlider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(heatSlider.value >= 1 && lost != true) {
			gameController.GetComponent<GameOver>().HeatLose();
			lost = true;
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

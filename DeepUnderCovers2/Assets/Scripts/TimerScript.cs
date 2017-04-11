using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour {
	public float increaseAmount = 0.1f;

	public GameObject gameController;
	static Slider timerSlider;
	private bool won;

	// Use this for initialization
	void Start () {
		timerSlider = GetComponent<Slider> ();
		won = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(timerSlider.value >= 1 && won != true) {
			gameController.GetComponent<GameOver> ().WinGame ();
			won = true;
		}

		timerSlider.value = timerSlider.value + increaseAmount * Time.deltaTime;
		
	}
}

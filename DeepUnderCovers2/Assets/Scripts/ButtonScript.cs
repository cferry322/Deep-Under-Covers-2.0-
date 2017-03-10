using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	bool pressed;
	public float increaseHeatAmount = 0.2f;
	public float decreaseHeatAmount = 0.2f;

	void Start(){
		pressed = false;
	}

	public void ButtonPressed() {
		pressed = true;
		MonsterMoverScript.MonsterButtonDown ();
		MoverScript.MoverButtonDown ();
	}

	public void ButtonReleased(){
		pressed = false;
		MonsterMoverScript.MonsterButtonUp ();
		MoverScript.MoverButtonUp ();
	}

	void Update(){

		if (pressed) {
			HeatControlScript.DecraseSlider (decreaseHeatAmount * Time.deltaTime);

		} else {
			HeatControlScript.IncreaseSlider (increaseHeatAmount * Time.deltaTime);
		}

	}

	}

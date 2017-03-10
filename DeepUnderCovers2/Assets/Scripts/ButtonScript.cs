using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	bool rightArmPressed;
	bool leftArmPressed;
	bool rightLegPressed;
	bool leftLegPressed;

	public float increaseHeatAmount = 0.2f;
	public float decreaseHeatAmount = 0.2f;

	void Start(){
		rightArmPressed = false;
	}

	//this function calls both MoverScript and MonsterMoverScript
	public void RightArmButtonPressed() {
		rightArmPressed = true;
		MonsterMoverScript.MonsterButtonDown ();
		MoverScript.ArmButtonDown ();
	}

	public void RightArmButtonReleased(){
		rightArmPressed = false;
		MonsterMoverScript.MonsterButtonUp ();
		MoverScript.ArmButtonUp ();
	}
	public void RightLegButtonPressed() {
		rightLegPressed = true;
		MonsterMoverScript.LegMonsterButtonDown ();
		MoverScript.LegButtonDown ();
	}

	public void RightLegButtonReleased(){
		rightLegPressed = false;
		MonsterMoverScript.LegMonsterButtonUp ();
		MoverScript.LegButtonUp ();
	}

	void Update(){

		if (rightArmPressed || rightLegPressed || leftArmPressed || leftLegPressed) {
			HeatControlScript.DecraseSlider (decreaseHeatAmount * Time.deltaTime);
		} else {
			HeatControlScript.IncreaseSlider (increaseHeatAmount * Time.deltaTime);
		}

	}

	/*
	MonsterMoverScript.MonsterButtonDown ();
	MoverScript.MoverButtonDown ();
	LeftMonsterMoverScript.MonsterButtonDown ();
	LeftMoverScript.MoverButtonDown ();

	MonsterMoverScript.MonsterButtonUp ();
		MoverScript.MoverButtonUp ();
		LeftMonsterMoverScript.MonsterButtonUp ();
		LeftMoverScript.MoverButtonUp ();
*/
	}

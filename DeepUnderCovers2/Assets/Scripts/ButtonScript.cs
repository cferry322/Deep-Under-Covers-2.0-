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
        rightLegPressed = false;
        leftArmPressed = false;
        leftLegPressed = false;

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

    public void LeftArmButtonPressed()
    {
        leftArmPressed = true;
        LeftMonsterMoverScript.MonsterButtonDown();
        LeftMoverScript.ArmButtonDown();
    }

    public void LeftArmButtonReleased()
    {
        leftArmPressed = false;
        LeftMonsterMoverScript.MonsterButtonUp();
        LeftMoverScript.ArmButtonUp();
    }
    public void LeftLegButtonPressed()
    {
        leftLegPressed = true;
        LeftMonsterMoverScript.LegMonsterButtonDown();
        LeftMoverScript.LegButtonDown();
    }

    public void LeftLegButtonReleased()
    {
        leftLegPressed = false;
        LeftMonsterMoverScript.LegMonsterButtonUp();
        LeftMoverScript.LegButtonUp();
    }

    void Update(){

		if (rightArmPressed || rightLegPressed || leftArmPressed || leftLegPressed) {
			HeatControlScript.DecraseSlider (decreaseHeatAmount / 4 * Time.deltaTime);
		} else {
			HeatControlScript.IncreaseSlider (increaseHeatAmount / 4 * Time.deltaTime);
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

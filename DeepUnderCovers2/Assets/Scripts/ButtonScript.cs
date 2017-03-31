using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public AudioSource limbs;

	//this function calls both MoverScript and MonsterMoverScript
	public void RightArmButtonPressed() {
		MonsterMoverScript.MonsterButtonDown ();
		MoverScript.ArmButtonDown ();
	}

	public void RightArmButtonReleased(){
		MonsterMoverScript.MonsterButtonUp ();
		MoverScript.ArmButtonUp ();
		limbs.Play ();
	}
	public void RightLegButtonPressed() {
		MonsterMoverScript.LegMonsterButtonDown ();
		MoverScript.LegButtonDown ();
	}

	public void RightLegButtonReleased(){
		MonsterMoverScript.LegMonsterButtonUp ();
		MoverScript.LegButtonUp ();
		limbs.Play ();
	}

    public void LeftArmButtonPressed()
    {
        LeftMonsterMoverScript.MonsterButtonDown();
        LeftMoverScript.ArmButtonDown();
    }

    public void LeftArmButtonReleased()
    {
        LeftMonsterMoverScript.MonsterButtonUp();
        LeftMoverScript.ArmButtonUp();
		limbs.Play ();
    }
    public void LeftLegButtonPressed()
    {
        LeftMonsterMoverScript.LegMonsterButtonDown();
        LeftMoverScript.LegButtonDown();
    }

    public void LeftLegButtonReleased()
    {
        LeftMonsterMoverScript.LegMonsterButtonUp();
        LeftMoverScript.LegButtonUp();
		limbs.Play ();
    }
		
 }

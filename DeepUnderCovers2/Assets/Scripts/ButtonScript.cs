using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public AudioSource limbs;
	public AudioClip limbsOut;

	//this function calls both MoverScript and MonsterMoverScript
	public void RightArmButtonPressed() {
		MonsterMoverScript.MonsterButtonDown ();
		MoverScript.ArmButtonDown ();
		limbs.PlayOneShot (limbsOut);
	}

	public void RightArmButtonReleased(){
		MonsterMoverScript.MonsterButtonUp ();
		MoverScript.ArmButtonUp ();
	}
	public void RightLegButtonPressed() {
		MonsterMoverScript.LegMonsterButtonDown ();
		MoverScript.LegButtonDown ();
		limbs.PlayOneShot (limbsOut);
	}

	public void RightLegButtonReleased(){
		MonsterMoverScript.LegMonsterButtonUp ();
		MoverScript.LegButtonUp ();
	}

    public void LeftArmButtonPressed()
    {
        LeftMonsterMoverScript.MonsterButtonDown();
        LeftMoverScript.ArmButtonDown();
		limbs.PlayOneShot (limbsOut);
    }

    public void LeftArmButtonReleased()
    {
        LeftMonsterMoverScript.MonsterButtonUp();
        LeftMoverScript.ArmButtonUp();
    }
    public void LeftLegButtonPressed()
    {
        LeftMonsterMoverScript.LegMonsterButtonDown();
        LeftMoverScript.LegButtonDown();
		limbs.PlayOneShot (limbsOut);
    }

    public void LeftLegButtonReleased()
    {
        LeftMonsterMoverScript.LegMonsterButtonUp();
        LeftMoverScript.LegButtonUp();
    }
		
 }

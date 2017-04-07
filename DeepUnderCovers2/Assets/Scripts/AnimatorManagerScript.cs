using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerScript : MonoBehaviour {

	public Animator anim;

	public void SetWinBool () {
		anim.SetBool ("Win", true);
	}
}

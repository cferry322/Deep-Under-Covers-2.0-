using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour {

	public AudioSource sounds;
	public Toggle toggle;


	public void Mute() 
	{
		if (sounds.mute)
			sounds.mute = false;
		else
			sounds.mute = true;
	}
}

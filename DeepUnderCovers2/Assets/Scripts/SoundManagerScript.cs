using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour {

	public AudioSource sounds;
	public AudioSource music;
	public AudioClip buttonClick;
	public Toggle toggle;


	void Start() {
		if (this.gameObject.name == "Toggle Sound" && PlayerPrefs.GetInt ("sound") == 1) {
			toggle.isOn = false;
		} else if (this.gameObject.name == "Toggle Music" && PlayerPrefs.GetInt ("music") == 1) {
			toggle.isOn = false;
		} else {
			toggle.isOn = true;
		}
	}

	public void MuteSounds() 
	{
		sounds.PlayOneShot (buttonClick);
		if (!toggle.isOn) {
			PlayerPrefs.SetInt ("sound", 1);
			sounds.mute = false;
		} else {
			PlayerPrefs.SetInt ("sound", 0);
			sounds.mute = true;
		}
	}

	public void MuteMusic() 
	{
		sounds.PlayOneShot (buttonClick);
		if (!toggle.isOn) {
			PlayerPrefs.SetInt ("music", 1);
			music.mute = false;
		} else {
			PlayerPrefs.SetInt ("music", 0);
			music.mute = true;
		}
	}
}

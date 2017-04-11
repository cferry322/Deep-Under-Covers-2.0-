using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenuScript : MonoBehaviour {

	public AudioSource sound;
	public AudioClip buttonClick;

	public GameObject soundMenu;
	public Button xButton;


	public void SoundMenuEnter() {

		Time.timeScale = 0.0f;
		soundMenu.gameObject.SetActive (true);
		xButton.interactable = false;
		sound.PlayOneShot (buttonClick);
	}

	public void SoundMenuExit() {

		Time.timeScale = 1.0f;
		soundMenu.gameObject.SetActive (false);
		xButton.interactable = true;
		sound.PlayOneShot (buttonClick);
	}
}

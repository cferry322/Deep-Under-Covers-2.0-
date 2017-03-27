using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuScript : MonoBehaviour {

	public GameObject soundMenu;
	public GameObject xButton;

	public void SoundMenuEnter() {

		Time.timeScale = 0.0f;
		soundMenu.gameObject.SetActive (true);
		xButton.gameObject.SetActive (false);
	}

	public void SoundMenuExit() {

		Time.timeScale = 1.0f;
		soundMenu.gameObject.SetActive (false);
		xButton.gameObject.SetActive (true);
	}
}

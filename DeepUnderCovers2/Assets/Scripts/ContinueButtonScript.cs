using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButtonScript : MonoBehaviour {

	public Button continueButton;

	void Start() {
		if (PlayerPrefs.GetInt ("level number") > 0) {
			continueButton.interactable = true;
		} else {
			continueButton.interactable = false;
		}
	}

	public void ContinueLevel()
	{
		SceneManager.LoadSceneAsync (PlayerPrefs.GetInt ("level number"));
	}
}

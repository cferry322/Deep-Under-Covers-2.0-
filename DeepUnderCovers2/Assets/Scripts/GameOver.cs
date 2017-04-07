using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {



	static bool lose;
	static bool win;
	bool start;

	int scene;
	public GameObject boyHead;
	public GameObject controlButtons;
	public GameObject panel;
	public GameObject restartButton;
	public GameObject nextLevelButton;
	public Slider heatSlider;
	public Slider timerSlider;
	public Text gameOverText;
	public AudioSource theme;


	//pause the game until they tap
	void Start () {

		start = true;
        lose = false;
        win = false;
        gameOverText.text = "Tap to Start";
		Time.timeScale = 0.0f;
		scene = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt ("level number", scene);
		Debug.Log (PlayerPrefs.GetInt ("level number", scene));
	}
		
	// Update is called once per frame
	void Update () {

		//only called at the start
		if (start) {
			if (Input.GetButtonDown ("Fire1")) {
				Time.timeScale = 1.0f;
				gameOverText.gameObject.SetActive(false);
                start = false;
				theme.Play ();
				if (PlayerPrefs.GetInt ("music") == 0) {
					theme.mute = true;
				} else 
				{
					theme.mute = false;
				}
			}
		}

		if (lose) {
			theme.Pause();
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Lose!";
			panel.gameObject.SetActive(true);
			restartButton.gameObject.SetActive(true);
			controlButtons.SetActive (false);
		}

		if (win) {
			theme.Pause();
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Win!";
			panel.gameObject.SetActive (true);
			controlButtons.SetActive (false);
			nextLevelButton.gameObject.SetActive(true);

		}

	}

	public void HeatLose() {
		lose = true;
		Time.timeScale = 0;
	}


	public void LoseGame() {
		lose = true;
		boyHead.GetComponent<SweatScript> ().LoseTrue ();
		Time.timeScale = 0;
	}
	public void WinGame() {
		win = true;
		boyHead.GetComponent<SweatScript> ().WinTrue ();
		if (PlayerPrefs.GetInt ("level number") == 2) 
		{
			PlayerPrefs.SetInt ("level number", 0);
		}
		Time.timeScale = 0;
	}
}

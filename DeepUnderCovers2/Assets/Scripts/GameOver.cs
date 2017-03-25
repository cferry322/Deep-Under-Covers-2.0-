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
	}
	
	// Update is called once per frame
	void Update () {

		//only called at the start
		if (start) {
			if (Input.GetButtonDown ("Fire1")) {
				Time.timeScale = 1.0f;
                gameOverText.text = "";
                start = false;
				theme.Play();
			}
		}

		if (Time.timeScale == 1.0f) {
			theme.UnPause();
		} else {
			theme.Pause();
		}

		if (lose) {
			gameOverText.text = "You Lose!";
			panel.gameObject.SetActive(true);
			restartButton.gameObject.SetActive(true);

		}
		if (win) {
			gameOverText.text = "You Win!";
			panel.gameObject.SetActive (true);
			nextLevelButton.gameObject.SetActive(true);
		}

	}
	public static void LoseGame() {
		lose = true;
		Time.timeScale = 0;
	}
	public static void WinGame() {
		win = true;
		if (PlayerPrefs.GetInt ("level number") == 2) 
		{
			PlayerPrefs.SetInt ("level number", 0);
		}
		Time.timeScale = 0;
	}
}

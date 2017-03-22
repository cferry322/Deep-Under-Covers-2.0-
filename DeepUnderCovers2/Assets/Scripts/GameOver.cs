using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {


	static bool lose;
	static bool win;
	static bool restart;
	bool start;

	public GameObject panel;
	public GameObject restartButton;
	public GameObject nextLevelButton;
	public Slider heatSlider;
	public Slider timerSlider;
	public Text gameOverText;
	public Text restartText;

	//pause the game until they tap
	void Start () {
		start = true;
		restart = false;
		gameOverText.text = "";
		restartText.text = "Tap to Start";
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		//only called at the start
		if (start) {
			if (Input.GetButtonDown ("Fire1")) {
				Time.timeScale = 1.0f;
				restartText.text = "";
			}
		}

		if (restart) {
			restartText.text = "Tap to restart";
			if (Input.GetButtonDown ("Fire1"))
			{
				SceneManager.LoadScene("Level 1");
				restart = false;
				lose = false;
				win = false;
				gameOverText.text = "";
				restartText.text = "";
				Time.timeScale = 1;

			}
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
		restart = true;
		Time.timeScale = 0;
	}
	public static void WinGame() {
		win = true;
		restart = true;
		Time.timeScale = 0;
	}
}

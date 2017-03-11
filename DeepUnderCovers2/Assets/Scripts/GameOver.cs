using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {


	static bool lose;
	static bool win;
	static bool restart;

	public Slider heatSlider;
	public Slider timerSlider;
	public Text gameOverText;
	public Text restartText;

	// Use this for initialization
	void Start () {
		gameOverText.text = "";
		restartText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if (restart) {
			restartText.text = "Tap to restart";
			if (Input.GetButtonDown ("Fire1"))
			{
				SceneManager.LoadScene("DanWorkshop");
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
		}
		if (win) {
			gameOverText.text = "You Win!";
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

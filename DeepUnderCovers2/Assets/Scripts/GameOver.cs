using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

	static bool lose;
	static bool win;

	public Slider heatSlider;
	public Slider timerSlider;
	public Text gameOverText;
	// Use this for initialization
	void Start () {
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (lose) {
			gameOverText.text = "You Lose!";
		}
		if (win) {
			gameOverText.text = "You Win!";
		}

	}
	public static void LoseGame() {
		lose = true;
	}
	public static void WinGame() {
		win = true;
	}
}

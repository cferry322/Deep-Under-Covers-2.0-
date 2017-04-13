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
	public GameObject calendar;
	public GameObject boyHead;
	public GameObject controlButtons;
	public GameObject panel;
	public GameObject restartButton;
	public GameObject nextLevelButton;
	public Slider heatSlider;
	public Slider timerSlider;
	public Text gameOverText;
	public Text calendarText;
	public AudioSource music;
	public AudioSource sound;
	public AudioClip winClip;
	public AudioClip loseClip;

	private int calendarNumber;


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
		calendarNumber = PlayerPrefs.GetInt ("level number", scene);
		calendarText.text = calendarNumber.ToString();

	}
		
	// Update is called once per frame
	void Update () {

		//only called at the start
		//starts the music and the time
		if (start) {
			if (Input.GetButtonDown ("Fire1")) {
				Time.timeScale = 1.0f;
				gameOverText.gameObject.SetActive(false);
                start = false;
				calendar.gameObject.SetActive (false);
				music.Play ();
				if (PlayerPrefs.GetInt ("music") == 0) {
					music.mute = true;
				} else {
					music.mute = false;
				}
			}
		}
		//enables UI panel with option to restart
		if (lose) {
			music.Pause();
			gameOverText.rectTransform.anchoredPosition = new Vector3 (0, -350, 0);
			gameOverText.fontSize = 80;
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Lose!";
			panel.gameObject.SetActive(true);
			restartButton.gameObject.SetActive(true);
			controlButtons.SetActive (false);
		}
		//enables the UI panel with option to go to next level
		if (win) {
			music.Pause();
			gameOverText.rectTransform.anchoredPosition = new Vector3 (0, -350, 0);
			gameOverText.fontSize = 80;
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Win!";
			panel.gameObject.SetActive (true);
			controlButtons.SetActive (false);
			nextLevelButton.gameObject.SetActive(true);

		}

	}
	//called when the heat reaches max
	public void HeatLose() {
		lose = true;
		Time.timeScale = 0;
		sound.PlayOneShot (loseClip);
	}

	//called when monster touches
	public void LoseGame() {
		lose = true;
		boyHead.GetComponent<SweatScript> ().LoseTrue ();
		sound.PlayOneShot (loseClip);
		Time.timeScale = 0;
	}
	//called when the timer reaches max
	public void WinGame() {
		win = true;
		boyHead.GetComponent<SweatScript> ().WinTrue ();
		if (PlayerPrefs.GetInt ("level number") == 2) 
		{
			PlayerPrefs.SetInt ("level number", 0);
		}
		sound.PlayOneShot (winClip);
		Time.timeScale = 0;
	}
}

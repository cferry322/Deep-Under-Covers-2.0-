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
    public GameObject infinite;
	public Slider heatSlider;
	public Slider timerSlider;
    public Text restartButtonText;
	public Text gameOverText;
	public Text calendarText;
    public Text highScoreText;
    public Text lastRoundScoreText;
	public AudioSource music;
	public AudioSource sound;
	public AudioClip winClip;
	public AudioClip loseClip;

	private int calendarNumber;
    private int infitineNumber;
    private string sceneName;
    private int lastRoundScore;
    private int highScore;

	//pause the game until they tap
	void Start () {

        infitineNumber = PlayerPrefs.GetInt("Infinite level");
        lastRoundScore = PlayerPrefs.GetInt("LastRoundScore");
        highScore = PlayerPrefs.GetInt("HighScore");
        sceneName = SceneManager.GetActiveScene().name;

		start = true;
        lose = false;
        win = false;
		Time.timeScale = 0.0f;
        if (sceneName == "Infinite")
        {
            calendarText.text = infitineNumber.ToString();
            lastRoundScoreText.text += lastRoundScore.ToString();
            highScoreText.text += highScore.ToString();
        }
        else {
            scene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("level number", scene);
            Debug.Log(PlayerPrefs.GetInt("level number", scene));
            calendarNumber = PlayerPrefs.GetInt("level number", scene);
            calendarText.text = calendarNumber.ToString();
        }
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
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    sound.mute = true;
                }
                else
                {
                    sound.mute = false;
                }
            }
		}
		//enables UI panel with option to restart
		if (lose) {
			music.Pause();
			gameOverText.fontSize = 80;
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Lose!";
			panel.gameObject.SetActive(true);
			restartButton.gameObject.SetActive(true);
			controlButtons.SetActive (false);
            if (sceneName == "Infinite")
            {
                infinite.gameObject.SetActive(true);
            }
            lose = false;
		}
		//enables the UI panel with option to go to next level
		if (win) {
			music.Pause();
			gameOverText.fontSize = 80;
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "You Win!";
			panel.gameObject.SetActive (true);
			controlButtons.SetActive (false);
            if (sceneName == "Infinite")
            {
                if (highScore <= infitineNumber)
                {
                    highScore = infitineNumber;
                    PlayerPrefs.SetInt("HighScore", highScore + 1);
                }
                PlayerPrefs.SetInt("Infinite level", infitineNumber + 1);
                restartButtonText.text = "Next Level";
                restartButton.gameObject.SetActive(true);
                infinite.gameObject.SetActive(true);
            }
            else
            {
                nextLevelButton.gameObject.SetActive(true);
            }
            win = false;
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

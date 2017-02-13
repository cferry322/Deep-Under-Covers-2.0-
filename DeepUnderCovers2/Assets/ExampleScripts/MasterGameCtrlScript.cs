using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterGameCtrlScript : MonoBehaviour {

    public Image flash;
    public float loseFlashSpeed;
    public float loseDelay;
    public float winFadeSpeed;
    public Color loseFlashColor;
    public Color winFadeColor;
    public SpriteRenderer head;
    public Sprite sleepHead;
    public Sprite terrorHead;
    public Animator gameOver;
    public ScoreManagerScript score;
    public int nextLevel;
    public int mainMenu;
    public Animator background;
    public AudioSource doorCreek;

    static bool win;
    static bool lose;
    float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(lose && elapsedTime == 0)
        {
            //TODO set background to awake

            background.SetTrigger("GameEnded");
            doorCreek.Play();
            gameOver.gameObject.SetActive(true);
            score.enabled = false;
            head.sprite = terrorHead;
            flash.color = loseFlashColor;
            elapsedTime += Time.deltaTime;
        } else if (lose && elapsedTime < loseFlashSpeed + loseDelay )
        {
            flash.color = Color.Lerp(flash.color, Color.clear, loseFlashSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        } else if (lose && elapsedTime >= loseFlashSpeed + loseDelay)
        {
            //TODO reset to main menu
            elapsedTime = 0;
            lose = false;
            gameOver.gameObject.SetActive(false);
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        } else if (win && elapsedTime < winFadeSpeed)
        {
            if (score.enabled)
            {
                Debug.Log("win");
                score.IncreaseScore(10000f);
            }
            score.enabled = false;
            head.sprite = sleepHead;
            flash.color = Color.Lerp(flash.color, winFadeColor, winFadeSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        } else if (win && elapsedTime >= winFadeSpeed)
        {
            //TODO go to next level or main menu
            elapsedTime = 0;
            win = false;
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
	}

    public static void EndNight()
    {
        win = true;
    }

    public static void LoseGame()
    {
        lose = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {
	public float increaseAmount;

	public GameObject gameController;
	static Slider timerSlider;
	private bool won;

	// Use this for initialization
	void Start () {
		timerSlider = GetComponent<Slider> ();
		won = false;

        if (SceneManager.GetActiveScene().name == "Infinite")
        {
            if (increaseAmount < 0.1f && increaseAmount > 0.05f)
            {
                increaseAmount = 0.1f - (PlayerPrefs.GetInt("Infinite level") / 100);
            }
        }


    }
	
	// Update is called once per frame
	void Update () {

		if(timerSlider.value >= 1 && won != true) {
			gameController.GetComponent<GameOver> ().WinGame ();
			won = true;
		}

		timerSlider.value = timerSlider.value + increaseAmount * Time.deltaTime;
		
	}
}

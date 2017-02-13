using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManagerScript : MonoBehaviour {

    public float scoreRateValue = 100;
    public Text textBox;

    float score = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score += scoreRateValue * Time.deltaTime;
        textBox.text = "Score: " + Mathf.Floor(score);
	}

    public void IncreaseScore(float s)
    {
        this.score += s;
        textBox.text = "Score: " + Mathf.Floor(this.score);
    }
}

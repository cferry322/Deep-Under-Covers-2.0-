using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MonsterBoundary
{
	public float leftBoundary, rightBoundary;
}

public class MonsterMoverScript : MonoBehaviour {

	public GameObject gameController;
	static private bool armPressed;
	static private bool legPressed;

	public float speedRight;
	public float speedLeft;
	public MonsterBoundary boundary;

	void Start(){
		armPressed = false;
		legPressed = false;
        if (SceneManager.GetActiveScene().name == "Infinite")
        {
            MonsterFaster();
        }
    }

	void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Arm") || other.CompareTag("Leg"))
        {
			gameController.GetComponent<GameOver> ().LoseGame ();
        }
	}

    public void MonsterFaster()
    {
        if (speedRight < 10)
        {
            speedRight = speedRight + PlayerPrefs.GetInt("Infinite level");
        }
        else if (speedRight >= 10 && speedRight < 15)
        {
            speedRight = speedRight + (PlayerPrefs.GetInt("Infinite level") / 10);
        }


        if (speedLeft < 10)
        {
            speedLeft = speedLeft + PlayerPrefs.GetInt("Infinite level");
        }
        else if (speedLeft >= 10 && speedLeft < 15)
        {
            speedLeft = speedLeft + (PlayerPrefs.GetInt("Infinite level") / 10);
        }
    }

    static public void MonsterButtonDown(){
		armPressed = true;
	}
	static public void MonsterButtonUp(){
		armPressed = false;
	}
	static public void LegMonsterButtonDown(){
		legPressed = true;
	}
	static public void LegMonsterButtonUp(){
		legPressed = false;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 
			(
				Mathf.Clamp (this.transform.position.x, boundary.leftBoundary, boundary.rightBoundary), 
				this.transform.position.y, 
				0.0f
			);
		if (this.CompareTag("Arm") && armPressed) 
		{
			this.transform.Translate(-0.1f * speedLeft * Time.deltaTime, 0.0f, 0.0f);
		} 
		else if (this.CompareTag("Arm") && !armPressed)
		{
			this.transform.Translate(0.1f * speedRight * Time.deltaTime, 0.0f, 0.0f);
		}

		if (this.CompareTag("Leg") && legPressed) 
		{
			this.transform.Translate(-0.1f * speedLeft * Time.deltaTime, 0.0f, 0.0f);
		} 
		else if (this.CompareTag("Leg") && !legPressed)
		{
			this.transform.Translate(0.1f * speedRight * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterBoundary
{
	public float leftBoundary, rightBoundary;
}

public class MonsterMoverScript : MonoBehaviour {


	static private bool pressed;
	static private bool legPressed;

	public float speedRight;
	public float speedLeft;
	public MonsterBoundary boundary;

	void Start(){
		pressed = false;
		legPressed = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player"))
			GameOver.LoseGame();
	}

	static public void MonsterButtonDown(){
		pressed = true;
	}
	static public void MonsterButtonUp(){
		pressed = false;
	}
	static public void LegMonsterButtonDown(){
		pressed = true;
	}
	static public void LegMonsterButtonUp(){
		pressed = false;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 
			(
				Mathf.Clamp (this.transform.position.x, boundary.leftBoundary, boundary.rightBoundary), 
				this.transform.position.y, 
				0.0f
			);
		if (pressed) 
		{
			this.transform.Translate(-0.1f * speedLeft, 0.0f, 0.0f);
		} 
		else if (!pressed)
		{
			this.transform.Translate(0.1f * speedRight, 0.0f, 0.0f);
		}
		if (legPressed) 
		{
			this.transform.Translate(-0.1f * speedLeft, 0.0f, 0.0f);
		} 
		else if (!legPressed)
		{
			this.transform.Translate(0.1f * speedRight, 0.0f, 0.0f);
		}
	}
}
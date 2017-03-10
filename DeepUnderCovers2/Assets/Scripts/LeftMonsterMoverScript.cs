using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMonsterMoverScript : MonoBehaviour {


	static private bool pressed;

	public float speedRight;
	public float speedLeft;
	public MonsterBoundary boundary;

	void Start(){
		pressed = false;
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

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 
			(
				Mathf.Clamp (this.transform.position.x, boundary.leftBoundary, boundary.rightBoundary), 
				this.transform.position.y, 
				0.0f
			);
		if (pressed) {

			this.transform.Translate(0.1f * speedRight, 0.0f, 0.0f);


		} else {

			this.transform.Translate(-0.1f * speedLeft, 0.0f, 0.0f);
		}
	}
}
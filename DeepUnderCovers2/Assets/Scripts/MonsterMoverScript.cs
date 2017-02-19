using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

public class MonsterMoverScript : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float loseDelay = 2.0f;
	public float speedOut;
	public float speedIn;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player"))
			GameOver.LoseGame();
			Time.timeScale = 0;
		if (Time.unscaledDeltaTime >= loseDelay){
			
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 monsterMove = new Vector3 (1.0f, 0.0f, 0.0f);
		rb2d.position = new Vector3 
			(
				Mathf.Clamp (rb2d.position.x, boundary.xMin, boundary.xMax), 
				rb2d.position.y, 
				0.0f
			);
		if (Input.GetButton ("Fire1")) {

			rb2d.velocity = -monsterMove * speedIn;


		} else {

			rb2d.velocity = monsterMove * speedOut;
		}
	}
}
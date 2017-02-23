using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterBoundary
{
	public float leftBoundary, rightBoundary;
}

public class MonsterMoverScript : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float speedOut;
	public float speedIn;
	public MonsterBoundary boundary;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player"))
			GameOver.LoseGame();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 monsterMove = new Vector3 (1.0f, 0.0f, 0.0f);
		rb2d.position = new Vector3 
			(
				Mathf.Clamp (rb2d.position.x, boundary.leftBoundary, boundary.rightBoundary), 
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
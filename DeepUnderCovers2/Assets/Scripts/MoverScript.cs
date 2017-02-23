using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float leftBoundary, rightBoundary;
}

public class MoverScript : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float speedOut;
	public float speedIn;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 armMovement = new Vector3 (1.0f, 0.0f, 0.0f);
		rb2d.position = new Vector3 
			(
				Mathf.Clamp (rb2d.position.x, boundary.leftBoundary, boundary.rightBoundary), 
				0.0f, 
				0.0f
			);
		if (Input.GetButton ("Fire1")) {

			rb2d.velocity = armMovement * speedOut;


		} else {

			rb2d.velocity = -armMovement * speedIn;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

public class MoverScript : MonoBehaviour {

	private Rigidbody2D rb;

	public float speedOut;
	public float speedIn;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 armMovement = new Vector3 (1.0f, 0.0f, 0.0f);
		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				0.0f
			);
		if (Input.GetButton ("Fire1")) {

			rb.velocity = armMovement * speedOut;


		} else {

			rb.velocity = -armMovement * speedIn;
		}
	}
}
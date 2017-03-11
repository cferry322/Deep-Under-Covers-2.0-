using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoverScript : MonoBehaviour {

	static private bool armPressed;
	static private bool legPressed;

	public float speedRight;
	public float speedLeft;
	public Boundary boundary;

	void Start()
	{
		armPressed = false;
		legPressed = false;
	}


	static public void ArmButtonDown() {
		armPressed = true;
	}
	static public void ArmButtonUp(){
		armPressed = false;
	}
	static public void LegButtonDown() {
		legPressed = true;
	}
	static public void LegButtonUp(){
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
		if (CompareTag("Arm") && armPressed) 
		{
			this.transform.Translate(0.1f * speedRight * Time.deltaTime, 0.0f, 0.0f);
		} 
		else if (CompareTag("Arm")&& !armPressed) 
		{
			this.transform.Translate(-0.1f * speedLeft * Time.deltaTime, 0.0f, 0.0f);
		}
		if (CompareTag("Leg") && legPressed) 
		{
			this.transform.Translate(0.1f * speedRight * Time.deltaTime, 0.0f, 0.0f);
		} 
		else if (CompareTag("Leg") && !legPressed)
		{
			this.transform.Translate(-0.1f * speedLeft * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
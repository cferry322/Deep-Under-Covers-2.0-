using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCtrlScript : MonoBehaviour {

    public ButtonClickScript leftArm;
    public ButtonClickScript leftLeg;
    public ButtonClickScript rightArm;
    public ButtonClickScript rightLeg;

    bool leftSet;
    bool rightSet;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("LeftAxis") == 0 && leftSet)
        {
            leftArm.SetPressed(false);
            leftLeg.SetPressed(false);
            leftSet = false;
        }
        if (Input.GetAxis("RightAxis") == 0 && rightSet)
        {
            rightArm.SetPressed(false);
            rightLeg.SetPressed(false);
            rightSet = false;
        }
		if(Input.GetAxisRaw("LeftAxis") > 0)
        {
            //left arm pressed
            leftArm.SetPressed(true);
            leftSet = leftSet || true;
        }
        if (Input.GetAxisRaw("LeftAxis") < 0)
        {
            //left leg pressed
            leftLeg.SetPressed(true);
            leftSet = leftSet || true;
        }
        if (Input.GetAxisRaw("RightAxis") > 0)
        {
            //right arm pressed
            rightArm.SetPressed(true);
            rightSet = rightSet || true;
        }
        if (Input.GetAxisRaw("RightAxis") < 0)
        {
            //right leg pressed
            rightLeg.SetPressed(true);
            rightSet = rightSet || true;
        }
	}
}

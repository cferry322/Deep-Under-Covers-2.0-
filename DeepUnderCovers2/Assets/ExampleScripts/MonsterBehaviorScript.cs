using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehaviorScript : MonoBehaviour {

    public Slider leftArmSlider;
    public Slider leftLegSlider;
    public Slider rightArmSlider;
    public Slider rightLegSlider;

    public ButtonClickScript leftArm;
    public float leftArmSelectedLeftArmSpeed = 0.1f;
    public float leftLegSelectedLeftArmSpeed = 0.05f;

    public ButtonClickScript leftLeg;
    public float leftArmSelectedLeftLegSpeed = 0.05f;
    public float leftLegSelectedLeftLegSpeed = 0.1f;

    public ButtonClickScript rightArm;
    public float rightArmSelectedRightArmSpeed = 0.1f;
    public float rightLegSelectedRightArmSpeed = 0.05f;

    public ButtonClickScript rightLeg;
    public float rightArmSelectedRightLegSpeed = 0.05f;
    public float rightLegSelectedRightLegSpeed = 0.1f;

    public float cooldown = 0.2f;

    public float decreaseRate = 0.1f;

    float leftArmDistance = 0;
    float leftLegDistance = 0;
    float rightArmDistance = 0;
    float rightLegDistance = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool leftArmOut = leftArm.GetPressed();
        bool leftLegOut = leftLeg.GetPressed();
        bool rightArmOut = rightArm.GetPressed();
        bool rightLegOut = rightLeg.GetPressed();

        if(leftArmOut)
        {
            leftArmDistance += leftArmSelectedLeftArmSpeed * Time.deltaTime;
            leftLegDistance += leftArmSelectedLeftLegSpeed * Time.deltaTime;
        }
        if (leftLegOut)
        {
            leftArmDistance += leftLegSelectedLeftArmSpeed * Time.deltaTime;
            leftLegDistance += leftLegSelectedLeftLegSpeed * Time.deltaTime;
        }
        if (rightArmOut)
        {
            rightArmDistance += rightArmSelectedRightArmSpeed * Time.deltaTime;
            rightLegDistance += rightArmSelectedRightLegSpeed * Time.deltaTime;
        }
        if (rightLegOut)
        {
            rightArmDistance += rightLegSelectedRightArmSpeed * Time.deltaTime;
            rightLegDistance += rightLegSelectedRightLegSpeed * Time.deltaTime;
        }
        if(!rightArmOut && !rightLegOut)
        {
            rightArmDistance -= decreaseRate * Time.deltaTime;
            rightLegDistance -= decreaseRate * Time.deltaTime;
        }
        if(!leftArmOut && !leftLegOut)
        {
            leftArmDistance -= decreaseRate * Time.deltaTime;
            leftLegDistance -= decreaseRate * Time.deltaTime;
        }

        leftArmDistance = Mathf.Max(0, leftArmDistance);
        leftLegDistance = Mathf.Max(0, leftLegDistance);
        rightArmDistance = Mathf.Max(0, rightArmDistance);
        rightLegDistance = Mathf.Max(0, rightLegDistance);

        leftArmSlider.value = leftArmDistance;
        leftLegSlider.value = leftLegDistance;
        rightArmSlider.value = rightArmDistance;
        rightLegSlider.value = rightLegDistance;

        if(rightArmDistance >= 1 || rightLegDistance >= 1 || leftArmDistance >= 1 || leftLegDistance >= 1)
        {
            MasterGameCtrlScript.LoseGame();
            this.enabled = false;
        }
	}

    public float GetDistance(int limbDistance)
    {
        switch(limbDistance)
        {
            case 0: return leftArmDistance;
            case 1: return leftLegDistance;
            case 2: return rightArmDistance;
            case 3: return rightLegDistance; 
        }
        return -1;
    }
}

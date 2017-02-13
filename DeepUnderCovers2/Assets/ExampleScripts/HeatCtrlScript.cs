using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatCtrlScript : MonoBehaviour {

    public float rateOfIncrease = 0.1f;
    public float minSweetSpot = 0.3f;
    public float maxSweetSpot = 0.7f;
    public NightCtrlScript nightCtrl;
    public float waitTime = 0.7f;
    public float sweetSpotMulti = 0.02f;

    static Slider slider;
    float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
        } else 
		{
            slider.value += rateOfIncrease * Time.deltaTime;
        }
        if(slider.value > minSweetSpot && slider.value < maxSweetSpot)
        {
            nightCtrl.ProgressNight(sweetSpotMulti);
        }
       
        if(slider.value >= 1) {
            MasterGameCtrlScript.LoseGame();
            this.enabled = false;
        }
	}

    public static void DecraseSlider(float decreaseValue)
    {
        slider.value -= decreaseValue;
    }

    public static void IncreaseValue(float increaseValue)
    {
        slider.value += increaseValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightCtrlScript : MonoBehaviour {

    public float increaseAmount = 0.1f;

    Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if(slider.value >= 1)
        {
            MasterGameCtrlScript.EndNight();
            this.enabled = false;
        }
        slider.value += increaseAmount * Time.deltaTime;
		
	}

    public void ProgressNight(float sweetSpotMulti)
    {
        slider.value += sweetSpotMulti * Time.deltaTime;
    }


}

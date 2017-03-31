using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbHeatScript : MonoBehaviour {

    public float decreaseAmount;
    public float increaseAmount;

    private bool inTheZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTheZone = true;
        Debug.Log("In");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTheZone = false;
        Debug.Log("Out");

    }

    // Update is called once per frame
    void Update () {
        if (!inTheZone)
        {
            HeatControlScript.DecreaseSlider(decreaseAmount * Time.deltaTime / 40);
        } else
        {
            HeatControlScript.IncreaseSlider(increaseAmount * Time.deltaTime / 40);
        }
	}
    
}

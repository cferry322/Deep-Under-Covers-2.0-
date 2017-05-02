using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimbHeatScript : MonoBehaviour {

    public float decreaseAmount;
    public float increaseAmount;

    private bool inTheZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTheZone = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTheZone = false;

    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Infinite")
        {
            decreaseAmount = decreaseAmount + PlayerPrefs.GetInt("Infinite level");

            increaseAmount = increaseAmount + (PlayerPrefs.GetInt("Infinite level") / (3.5f - (PlayerPrefs.GetInt("Infinite level"))/ 10));
        }
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

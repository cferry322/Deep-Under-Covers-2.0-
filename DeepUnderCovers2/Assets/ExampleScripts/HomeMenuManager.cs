using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenuManager : MonoBehaviour {

    public AudioSource aud;
    public int level;
    public int hardLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("RightAxis") < 0)
        {
            aud.Play();
            LoadLevel(level);
        }
        if(Input.GetAxisRaw("LeftAxis") < 0)
        {
            aud.Play();
            LoadLevel(hardLevel);
        }
        if(Input.GetAxisRaw("RightAxis") > 0 && Input.GetAxisRaw("LeftAxis") > 0)
        {
            Application.Quit();
        }
	}

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

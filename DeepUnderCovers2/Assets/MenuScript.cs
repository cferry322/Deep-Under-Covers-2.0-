using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("sound", 1);
		PlayerPrefs.SetInt ("music", 1);
	}

}

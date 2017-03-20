using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class NewGameScript : MonoBehaviour {

	public void NewGamePressed(string newGameLevel)
	{

		SceneManager.LoadSceneAsync (newGameLevel);

	}
}

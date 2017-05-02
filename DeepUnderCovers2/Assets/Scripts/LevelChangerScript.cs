using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelChangerScript : MonoBehaviour
{

    public void NextLevel()
    {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void RestartLevel() {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

	public void LevelByName(string levelName) 
	{
        if (SceneManager.GetActiveScene().name == "Infinite") {
            PlayerPrefs.SetInt("Infinite level", 1);
        }

        SceneManager.LoadSceneAsync(levelName);
	}
}
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

	public void LevelByName(string levelName) 
	{
		SceneManager.LoadSceneAsync(levelName);
	}
}
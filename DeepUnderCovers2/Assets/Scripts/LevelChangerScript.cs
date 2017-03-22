using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelChangerScript : MonoBehaviour
{

    public void NextLevel(string nextLevel)
    {

        SceneManager.LoadSceneAsync(nextLevel);

    }
}
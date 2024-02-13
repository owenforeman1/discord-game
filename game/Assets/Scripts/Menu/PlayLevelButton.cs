using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelButton : MonoBehaviour
{

    public string LevelName;
    
    public void PlayButtonClick()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}

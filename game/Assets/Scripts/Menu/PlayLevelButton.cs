using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelButton : MonoBehaviour
{

    public string LevelName;
    public SoundManager soundManager;
    
    public void PlayButtonClick()
    {
        soundManager.Play("click");
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}

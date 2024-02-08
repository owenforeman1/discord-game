using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    
    int level1 = 1;
    
    public void PlayButtonClick()
    {
        SceneManager.LoadScene(level1, LoadSceneMode.Single);
    }
}

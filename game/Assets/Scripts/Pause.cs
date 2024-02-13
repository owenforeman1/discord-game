using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool gamePaused;

    // WARNING PAUSING IS NOT A SCENCE THING ITS A PROJECT SETTING AND DOES NOT GET RESET ON SCENCE LOAD!
    public bool isGamePaused()
    {
        return gamePaused;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;

    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }
    public void TogglePause()
    {
        if (gamePaused)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }
}

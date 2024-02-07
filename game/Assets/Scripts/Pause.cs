using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool gamePaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
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

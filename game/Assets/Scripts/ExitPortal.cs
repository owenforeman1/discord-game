using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    public string EndScreenName = "EndScreen";
    public GameManager GameManager;


    public bool CheckWin()
    {
        if (GameManager.SandCount >= GameManager.TotalSand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnGameWin()
    {
        WriteTimeToSceneBuffer();
        SceneManager.LoadScene(EndScreenName, LoadSceneMode.Single);
    }

    public void WriteTimeToSceneBuffer()
    {
        // Write Time to buffer
        float finishTime = FindObjectOfType<SpeedRunTimer>().GetFinishTime();
        TimeTracker timeTracker = GameObject.FindGameObjectWithTag("PermaObject").GetComponent<TimeTracker>();
        timeTracker.OnLevelWin(finishTime, GameManager.levelIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBody"))
        {
           if (CheckWin())
            {
                OnGameWin();
            }
        }
    }
}

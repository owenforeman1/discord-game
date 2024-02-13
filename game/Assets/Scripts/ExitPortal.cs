using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    string EndScreenName = "EndScreen";
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
        SceneManager.LoadScene(EndScreenName, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           if (CheckWin())
            {
                OnGameWin();
            }
        }
    }
}

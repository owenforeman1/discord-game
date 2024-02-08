using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    int EndScreenIndex = 3;
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
        SceneManager.LoadScene(EndScreenIndex, LoadSceneMode.Single);
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

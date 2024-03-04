using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaObject : MonoBehaviour
{
    // Player Data
    public int wins;
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PermaObject");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        LoadGameData();
    }


    private void LoadGameData()
    {
        PlayerPrefsInit();

        wins = PlayerPrefs.GetInt("Wins");
    }

    private void PlayerPrefsInit()
    {
        if (!PlayerPrefs.HasKey("Wins"))
        {
            print("Data Not Found, Creating Data");

            PlayerPrefs.SetInt("Wins", 0);
        }
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("Wins", wins);
    }

    void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void ResetWins()
    {
        wins = 0;
        PlayerPrefs.SetInt("Wins", 0);
    }
}

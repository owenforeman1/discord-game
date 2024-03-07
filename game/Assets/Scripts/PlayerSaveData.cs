using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    // Player Data
    public int wins = 0;
    public float levelTime1 = 59999f;
    public float levelTime2 = 59999f;
    public float levelTime3 = 59999f;
    public int levelsCompleted = 0;


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

        wins = PlayerPrefs.GetInt("wins");
        levelTime1 = PlayerPrefs.GetFloat("levelTime1");
        levelTime2 = PlayerPrefs.GetFloat("levelTime2");
        levelTime3 = PlayerPrefs.GetFloat("levelTime3");
        levelsCompleted = PlayerPrefs.GetInt("levelsCompleted");

    }

    private void PlayerPrefsInit()
    {
        if (!PlayerPrefs.HasKey("wins"))
        {
            PlayerPrefs.SetInt("wins", 0);
        }
        if (!PlayerPrefs.HasKey("levelTime1"))
        {
            PlayerPrefs.SetFloat("levelTime1", 59999f);
        }
        if (!PlayerPrefs.HasKey("levelTime2"))
        {
            PlayerPrefs.SetFloat("levelTime2", 59999f);
        }
        if (!PlayerPrefs.HasKey("levelTime3"))
        {
            PlayerPrefs.SetFloat("levelTime3", 59999f);
        }
        if (!PlayerPrefs.HasKey("levelsCompleted"))
        {
            PlayerPrefs.SetInt("levelsCompleted", 0);
        }
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("wins", wins);
        PlayerPrefs.SetFloat("levelTime1", levelTime1);
        PlayerPrefs.SetFloat("levelTime2", levelTime2);
        PlayerPrefs.SetFloat("levelTime3", levelTime3);
        PlayerPrefs.SetInt("levelsCompleted", levelsCompleted);
    }

    void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void ResetWins()
    {
        wins = 0;
        SaveGameData();
    }

    public void ResetTimes()
    {
        levelTime1 = 59999f;
        levelTime2 = 59999f;
        levelTime3 = 59999f;

        SaveGameData();
    }

    public List<float> GetRecordTimeList()
    {
        List<float> times = new List<float>()
        {
            levelTime1,
            levelTime2,
            levelTime3,
        };

        return times;
    }
}

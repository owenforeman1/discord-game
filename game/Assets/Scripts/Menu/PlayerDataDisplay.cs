using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDataDisplay : MonoBehaviour
{
    public string defaultWinsText = "Game Clears:";
    public TMP_Text gameClearsText;

    private PlayerSaveData PlayerSaveData;

    [SerializeField] List<TMP_Text> recordTextList = new List<TMP_Text>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerSaveData = GameObject.FindGameObjectWithTag("PermaObject").GetComponent<PlayerSaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplays();
        UpdateRecordTimes();
    }

    private void UpdateDisplays()
    {
        gameClearsText.SetText(defaultWinsText + " " + PlayerSaveData.wins);

        UpdateRecordTimes();
    }

    private void UpdateRecordTimes()
    {
        List<float> recordTimes = PlayerSaveData.GetRecordTimeList();

        int i = 0;
        foreach(TMP_Text recordText in recordTextList)
        {
            recordText.SetText("Level " + (i + 1).ToString() + " " + ConvertTimeToDisplayTimer(recordTimes[i]));
            i++;
        }
    }

    public void ResetGameClearsData()
    {
        PlayerSaveData.ResetWins();
    }
    public void ResetTimeRecordsData()
    {
        PlayerSaveData.ResetTimes();
    }

    private string ConvertTimeToDisplayTimer(float time)
    {
        int minutes = (int)time / 60;
        string seconds = ((int)(time - (float)minutes * 60)).ToString();
        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }


        string microseconds = time.ToString("0.00");
        microseconds = microseconds.Substring(microseconds.Length - 2);

        return $"{minutes}:{seconds}.{microseconds}";
    }
}

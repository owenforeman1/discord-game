using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{

    public TMP_Text timeText;
    public string defaultText = "Time: ";

    private void Start()
    {
        GameObject.FindAnyObjectByType<SoundManager>().Play("winsound");
        DisplayTimer();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void DisplayTimer()
    {
        //Get time
        TimeTracker TimeTracker = GameObject.FindGameObjectWithTag("PermaObject").GetComponent<TimeTracker>();
        // Update Text
        timeText.SetText(defaultText + ConvertTimeToDisplayTimer(TimeTracker.runTimeBuffer));
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

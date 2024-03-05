using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SpeedRunTimer : MonoBehaviour
{
    public TMP_Text text;

    public float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - StartTime;

        text.text = ConvertTimeToDisplayTimer(currentTime);
    }

    public float GetFinishTime()
    {
        return Time.time - StartTime;
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

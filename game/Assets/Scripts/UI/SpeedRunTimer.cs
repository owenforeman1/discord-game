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
        int minutes = (int)currentTime / 60;
        string seconds = ((int)(currentTime - (float)minutes * 60)).ToString();
        if(seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }


        string microseconds = currentTime.ToString("0.00");
        microseconds = microseconds.Substring(microseconds.Length - 2);
        //string microseconds = Math.Round((float)currentTime - (float)(minutes * 60) - (float)seconds, 2);


        text.text = $"{minutes}:{seconds}.{microseconds}";
    }
}

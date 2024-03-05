using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public PlayerSaveData PlayerSaveData;

    public float runTimeBuffer;


    public void OnLevelWin(float runTime, int level)
    {
        // Gets called when players beats a level

        runTimeBuffer = runTime;
        // Check to update new PB
        switch (level)
        {
            case 1:
                if (runTime < PlayerSaveData.levelTime1)
                {
                    PlayerSaveData.levelTime1 = runTime;
                }
                break; 
            case 2:
                if (runTime < PlayerSaveData.levelTime2)
                {
                    PlayerSaveData.levelTime2 = runTime;
                }
                break;
            case 3:
                if (runTime < PlayerSaveData.levelTime3)
                {
                    PlayerSaveData.levelTime3 = runTime;
                }
                break;

        }
    }
}

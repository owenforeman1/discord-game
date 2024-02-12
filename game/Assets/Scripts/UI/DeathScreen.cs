using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public DeathHandler DeathHandler;
    public GameObject DeathScreenUI;

    private Sprite KillerIMG = null;
    public GameObject DeathRecap;
    public UnityEngine.UI.Image DeathRecapImage;

    // Update is called once per frame
    void Update()
    {
        if (DeathHandler.PlayerIsDead)
        {
            // Display
            ShowDeathScreen();
        }
        else
        {
            DeathScreenUI.SetActive(false);
        }
    }

    public void LoadIMG(Sprite KillerIMGIn)
    {
        KillerIMG = KillerIMGIn;
    }

    private void ShowDeathScreen()
    {
        DeathScreenUI.SetActive(true);
        if(KillerIMG != null)
        {
            DeathRecapImage.sprite = KillerIMG;
        }
        else
        {
            DeathRecap.SetActive(false);
        }
        
    }
}

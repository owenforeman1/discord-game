using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantAnimHelper : MonoBehaviour
{
    public Merchant Merchant;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void CallGiveAirplane()
    {
        Merchant.GiveAirplane();
    }

    public void PlayPaperSound()
    {
        soundManager.Play("papersound");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool GodMode = false;
    
    public int health;
    public ProtectionPrayer ProtectionPrayer;
    public Shield Shield;
    public DeathHandler DeathHandler;

    public bool isDead;

    private void Update()
    {

    }

    public void GetHit(Sprite KillerIMG)
    {
        if (GodMode)
        {
            return;
        }

        if (Shield.isActive)
        {
            return;
        }
        if (isDead)
        {
            return;
        }

        DeathHandler.OnPlayerDeath(KillerIMG);

    }
}

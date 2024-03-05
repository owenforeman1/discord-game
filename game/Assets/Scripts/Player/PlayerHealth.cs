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
        CheckGodMode();
    }

    private void CheckGodMode()
    {
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GodMode = !GodMode;
            }
        }
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

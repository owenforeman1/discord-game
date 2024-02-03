using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public int health;
    public ProtectionPrayer ProtectionPrayer;


    public void GetHit(DamageType ProjectileType)
    {
        
        if (ProjectileType != ProtectionPrayer.Prayer)
        {
            // Was hit off prayer
            // Reload Scence For now
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}

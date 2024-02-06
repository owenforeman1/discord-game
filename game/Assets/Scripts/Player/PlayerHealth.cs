using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public int health;
    public ProtectionPrayer ProtectionPrayer;
    public Shield Shield;

    public bool isDead;

    private void Update()
    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    public void GetHit(DamageType ProjectileType)
    {
        if (Shield.isActive)
        {
            return;
        }
        
        
        if (ProjectileType != ProtectionPrayer.Prayer)
        {
            // Was hit off prayer
            // Reload Scence For now
            //string currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(currentSceneName);
            isDead = true;
        }
    }
}

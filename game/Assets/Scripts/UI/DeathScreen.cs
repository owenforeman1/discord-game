using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public GameObject DeathScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.isDead)
        {
            // Display
            DeathScreenUI.SetActive(true);
        }
        else
        {
            DeathScreenUI.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public bool PlayerIsDead;
    public Pause pause;
    public PlayerHealth playerHealth;
    public DeathScreen DeathScreen;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetGame();
            }
        }
    }

    public void ResetGame()
    {
        pause.UnpauseGame();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnPlayerDeath(Sprite KillerIMG)
    {
        // Set player death flags to True
        PlayerIsDead = true;
        playerHealth.isDead = true;
        // Death UI gets loaded
        DeathScreen.LoadIMG(KillerIMG);
        // Pause Game
        pause.PauseGame();
    }
}

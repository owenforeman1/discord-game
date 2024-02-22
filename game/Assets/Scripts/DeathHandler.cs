using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public bool PlayerIsDead;
    public Pause pause;
    private PlayerHealth playerHealth;
    public DeathScreen DeathScreen;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

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
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
    }

    public void OnPlayerDeath(Sprite KillerIMG)
    {
        // Set player death flags to True
        PlayerIsDead = true;
        playerHealth.isDead = true;
        // Death UI gets loaded
        DeathScreen.LoadIMG(KillerIMG);
        // Play Death Sound
        GameObject.FindAnyObjectByType<SoundManager>().Play("DeathScreen");
        GameObject.FindAnyObjectByType<SoundManager>().Play("hitsound");


        //Shake Screen
        //GameObject.FindAnyObjectByType<Camera>().gameObject.GetComponent<CameraShake>().enabled = true;

        // Pause Game
        pause.PauseGame();
    }
}

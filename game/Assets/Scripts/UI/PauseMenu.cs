using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuContainer;

    private Pause pause;

    private void Start()
    {
        pause = GameObject.FindObjectOfType<Pause>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        SoundManager SoundManager = FindObjectOfType<SoundManager>();
        SoundManager.Play("click");


        if (PauseMenuContainer.activeSelf)
        {
            PauseMenuContainer.SetActive(false);
            pause.UnpauseGame();

        }
        else
        {
            pause.PauseGame();
            PauseMenuContainer.SetActive(true);
        }
    }

    public void ExitToMainMenu()
    {
        pause.UnpauseGame();
        SoundManager SoundManager = FindObjectOfType<SoundManager>();
        SoundManager.Play("click");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        SoundManager SoundManager = FindObjectOfType<SoundManager>();
        SoundManager.Play("click");
        Application.Quit();
    }
}

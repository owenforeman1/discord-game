using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject LevelSelect;
    public GameObject PlayerDataDisplay;

    public SoundManager soundManager;

    public List<GameObject> MainButtons = new List<GameObject>();

    private void Start()
    {
        LevelSelect.SetActive(false);
        PlayerDataDisplay.SetActive(false);
    }


    public void ToggleLevelSelect()
    {
        soundManager.Play("click");

        LevelSelect.SetActive(!LevelSelect.activeSelf);

        if (LevelSelect.activeSelf )
        {
            HideButtons();
        }
        else
        {
            ShowButtons();
        }
    }

    public void ToggleDisplayPlayerData()
    {
        soundManager.Play("click");

        PlayerDataDisplay.SetActive(!PlayerDataDisplay.activeSelf);

        if (PlayerDataDisplay.activeSelf)
        {
            HideButtons();
        }
        else
        {
            ShowButtons();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideButtons()
    {
        foreach (GameObject buttonObj in MainButtons)
        {
            buttonObj.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (GameObject buttonObj in MainButtons)
        {
            buttonObj.SetActive(true);
        }
    }
}

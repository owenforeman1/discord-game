using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject LevelSelect;

    public List<GameObject> MainButtons = new List<GameObject>();

    private void Start()
    {
        LevelSelect.SetActive(false);
    }


    public void ToggleLevelSelect()
    {
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

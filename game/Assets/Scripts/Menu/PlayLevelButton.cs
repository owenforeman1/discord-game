using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLevelButton : MonoBehaviour
{

    public string LevelName;
    public SoundManager soundManager;

    public int levelNum = 0;
    public Button button;

    private PlayerSaveData PlayerSaveData;

    private void Start()
    {
        PlayerSaveData = FindObjectOfType<PlayerSaveData>();
    }

    private void Update()
    {
        if (PlayerSaveData.levelsCompleted < levelNum-1)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void PlayButtonClick()
    {
        soundManager.Play("click");
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}

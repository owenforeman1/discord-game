using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SandCounterUI : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text text;

    public string DefaultWords = "Sand: ";
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindAnyObjectByType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = DefaultWords + gameManager.SandCount.ToString() + "/" + gameManager.TotalSand.ToString();
    }
}

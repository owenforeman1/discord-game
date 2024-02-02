using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SandCounterUI : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Grains: " + gameManager.SandCount.ToString();
    }
}

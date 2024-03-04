using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerDataDisplay : MonoBehaviour
{
    public string defaultWinsText = "Game Clears:";
    public TMP_Text gameClearsText;

    private PermaObject PermaObject;

    // Start is called before the first frame update
    void Start()
    {
        PermaObject = GameObject.FindGameObjectWithTag("PermaObject").GetComponent<PermaObject>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplays();
    }

    private void UpdateDisplays()
    {
        gameClearsText.SetText(defaultWinsText + " " + PermaObject.wins);
    }

    public void ResetGameClearsData()
    {
        PermaObject.ResetWins();
    }
}

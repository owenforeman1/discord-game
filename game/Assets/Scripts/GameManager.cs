using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int SandCount;
    [HideInInspector]
    public int TotalSand;

    // Start is called before the first frame update
    void Start()
    {
        TotalSand = GameObject.FindObjectsOfType<Sand>().Count();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.timeScale = 1 + SandCount;
    }

    public void AddSand()
    {
        SandCount++;
    }
}

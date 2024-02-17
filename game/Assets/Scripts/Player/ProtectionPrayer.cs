using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProtectionPrayer : MonoBehaviour
{

    [SerializeField]
    private Shield Shield;

    private Pause pause;


    void Start()
    {
        pause = GameObject.FindObjectOfType<Pause>();
    }

    // Update is called once per frame
    void Update()
    {


        if (AllowInput())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shield.Toggle();
            }
        }

    }

    private bool AllowInput()
    {
        if (pause != null)
        {
            return !pause.isGamePaused();
        }
        else
        {
            return true;
        }
    }

}

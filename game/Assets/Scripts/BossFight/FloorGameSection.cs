using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGameSection : MonoBehaviour
{
    [SerializeField]
    private Sprite deathRecapIcon;

    private GameObject Player;

    private int playerpartsInside = 0;

    [HideInInspector] public bool floorIsLava;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {

        if (floorIsLava && playerIsInside())
        {
            Player.GetComponent<PlayerHealth>().GetHit(deathRecapIcon);
        }

    }

    private bool playerIsInside()
    {
        return playerpartsInside > 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "PlayerBody")
            {

                playerpartsInside += 1;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "PlayerBody")
            {
                playerpartsInside -= 1;

            }
        }
    }
}

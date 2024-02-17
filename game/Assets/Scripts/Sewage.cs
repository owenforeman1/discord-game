using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sewage : MonoBehaviour
{
    private bool playerInside;

    public float timeToKill = 1.5f;
    public float slowPercent = .8f;

    [SerializeField]
    private Sprite deathRecapIcon;

    private float insideTimer;

    private GameObject Player;
    private SewageIndicator SewageIndicator;
    private PlayerMovement playerMovement;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SewageIndicator = Player.GetComponent<SewageIndicator>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            insideTimer += Time.deltaTime;
        }
        else
        {
            insideTimer = 0f;
        }

        SewageIndicator.UpdateColor(insideTimer, timeToKill);

        if (insideTimer > timeToKill)
        {
            Player.GetComponent<PlayerHealth>().GetHit(deathRecapIcon);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                playerInside = true;
                playerMovement.ChangeModifier(true, slowPercent);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                playerInside = false;
                playerMovement.ChangeModifier(false, slowPercent);
            }
        }
    }


}

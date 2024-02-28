using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sewage : MonoBehaviour
{
    public float timeToKill = 1.5f;
    public float slowPercent = .8f;

    [SerializeField]
    private Sprite deathRecapIcon;

    private float insideTimer;

    private GameObject Player;
    private SewageIndicator SewageIndicator;
    private PlayerMovement playerMovement;

    private int playerpartsInside = 0;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SewageIndicator = Player.GetComponent<SewageIndicator>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerIsInside())
        {
            insideTimer += Time.deltaTime * Mathf.Clamp(playerpartsInside, 0, 3)/3;
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
                if (!playerIsInside())
                {
                    playerMovement.ChangeModifier(true, slowPercent);
                }

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

                if (!playerIsInside())
                {
                    playerMovement.ChangeModifier(false, slowPercent);
                }
                
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            GameManager.AddSand();
            GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // A scritp that a turns on a gameobject when the player walks into it

    public GameObject Object;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Object.SetActive(true);
        }
    }
}

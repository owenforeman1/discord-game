using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    [HideInInspector] public bool isEquiped;

    public Transform SpriteTransform;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEquiped) { return; }
        
        if (collision.CompareTag("Player"))
        {
            Equip();
        }
    }

    private void Equip()
    {
        isEquiped = true;

        // Set player To Parent
        transform.SetParent(playerTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        SpriteTransform.localRotation = Quaternion.Euler(0f, 0f, 20f);

    }

    public void TurnInEnvelope()
    {
        Destroy(gameObject);
    }
}

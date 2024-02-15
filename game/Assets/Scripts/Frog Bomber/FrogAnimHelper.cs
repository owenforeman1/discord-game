using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimHelper : MonoBehaviour
{
    SoundManager soundManager;
    Transform playerTransform;
    public float minDistanceToPlaySound = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayStepSound()
    {
        // Only play sound if close
        if (Vector2.Distance(playerTransform.position, transform.position) < minDistanceToPlaySound)
        {
            soundManager.Play("frogstep");
        }
        
        
    }
}

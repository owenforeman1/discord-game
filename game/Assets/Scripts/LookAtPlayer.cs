using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform PlayerTransform;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    // 0 is left 1 is right
    private int DefaultFacing = 0;

    // Default Direction
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If left
        if (PlayerTransform.position.x < transform.position.x)
        {
            if (DefaultFacing == 0)
            {
                spriteRenderer.flipX = false;
            }
            else 
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (DefaultFacing == 1)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}

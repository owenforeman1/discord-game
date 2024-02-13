using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBomber : MonoBehaviour
{
    // How close before we blow up
    public float expodeRange = 3f;
    public float runSpeed = 20f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject explosion;
    public GameObject particle1;
    public GameObject particle2;

    Transform playertransform;

    bool moveLocked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;


        if (!moveLocked && Vector2.Distance(transform.position, playertransform.position) < expodeRange)
        {
            StartCoroutine(ExplosionSequence());
        }

        if (!moveLocked)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        // Go to player
        Vector2 MoveDirection = (playertransform.position - transform.position).normalized;
        rb.velocity = runSpeed * MoveDirection;

    }

    IEnumerator ExplosionSequence()
    {
        moveLocked = true;
        animator.Play("explode");
        yield return new WaitForSeconds(50f/60f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(particle1, transform.position, Quaternion.identity);
        Instantiate(particle2, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}

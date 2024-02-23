using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubSegment : MonoBehaviour
{
    public float followDistance = 1f;
    public float headfollowDistance = 1.2f;


    public PlayerMovement playerMovement;

    public Transform followedSegment;

    public int index;

    public Animator animator;

    private Rigidbody2D rb;

    private bool needMove;

    public SpriteRenderer spriteRenderer;

    // Moves segment if out of range

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer.sortingOrder = index;

        //Head follow offset
        if (index == 1)
        {
            followDistance = headfollowDistance;
        }

        if (index != 0)
        {
            StartCoroutine(PlayDelayedAnim());
        }
            
    }

    IEnumerator PlayDelayedAnim()
    {


        yield return new WaitForSeconds(index * .15f);
        
        animator.Play("move");
    }

    // Update is called once per frame
    //private void Update()
    //{
    //needMove = OutOfRange();
    //}

    private void Update()
    {
        //needMove = OutOfRange();
    }


    void FixedUpdate()
    {
        needMove = OutOfRange();

        if (needMove)
        {
            MoveToNextSegment();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }


    }



    private void MoveToNextSegment()
    {
        float speed = playerMovement.activeMoveSpeed;
        //float speed = 25f;

        Vector2 Dir = (followedSegment.position - transform.position).normalized;
        transform.position += (Vector3)(Dir * speed * Time.fixedDeltaTime);
        //rb.velocity = Dir * speed;


        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Dir);
        transform.rotation = toRotation;
    }

    private bool OutOfRange()
    {
        if (Vector2.Distance(followedSegment.position, transform.position) > followDistance)
        {
            return true;
        }
        return false;
    }
}

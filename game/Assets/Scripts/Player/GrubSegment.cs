using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        spriteRenderer.sortingOrder = -index;

        //Head follow
        if (isHead())
        {
            followDistance = 0f;
        }
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

            // Rotate Anyway
            rotate();
        }


    }



    private void MoveToNextSegment()
    {
        float speed = playerMovement.activeMoveSpeed;

        float currentDistance = Vector2.Distance(followedSegment.position, transform.position);
        Vector2 Dir = (followedSegment.position - transform.position).normalized;

        if (currentDistance - (speed * Time.fixedDeltaTime) > followDistance)
        {
            transform.position += (Vector3)(Dir * speed * Time.fixedDeltaTime);
        }
        else
        {
            // Solve for correct postion 

            transform.position += (Vector3)(Dir * (currentDistance - followDistance));
        }

        rotate();


    }

    private void rotate()
    {
        Vector2 Dir;
        
        if (isHead())
        {
            Dir = playerMovement.inputVector;
        }
        else
        {
            Dir = (followedSegment.position - transform.position).normalized;
        }

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Dir);


        if (isHead())
        {
            if (Dir != Vector2.zero)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, .5f);
            }
        }
        else
        {
            transform.rotation = toRotation;
        }
        

    }

    private bool OutOfRange()
    {
        if (Vector2.Distance(followedSegment.position, transform.position) > followDistance)
        {
            return true;
        }
        return false;
    }

    private bool isHead()
    {
        return index == 0;
    }
}

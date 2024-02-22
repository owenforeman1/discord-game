using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubSegment : MonoBehaviour
{
    public static float followDistance = 1f;


    public PlayerMovement playerMovement;

    public Transform followedSegment;


    // Moves segment if out of range

    // Update is called once per frame
    void Update()
    {
        

        if (OutOfRange())
        {
            MoveToNextSegment();
        }


    }

    private void MoveToNextSegment()
    {
        float speed = playerMovement.activeMoveSpeed;

        Vector2 Dir = (followedSegment.position - transform.position).normalized;
        transform.position += (Vector3)(Dir * speed * Time.deltaTime);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWalk : MonoBehaviour
{
    // A script for a mob walking around

    private Transform playerTransform;
    [Header("Must Serialize")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 OriginPoint;

    // How far can they walk from Origin
    public float RoamDistance = 15f;

    public float walkspeed = 5f;

    public Vector2 WaitTime = new Vector2(3f, 6f);

    public float GiveUpTime = 3.5f;

    void Start()
    {
        OriginPoint = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(MainLoop());
    }


    private Vector2 PickPoint()
    {
        float newPointX = Random.Range(OriginPoint.x - RoamDistance, OriginPoint.x + RoamDistance);
        float newPointY = Random.Range(OriginPoint.y - RoamDistance, OriginPoint.y + RoamDistance);

        Vector2 newPoint = new Vector2(newPointX, newPointY);

        return newPoint;
    }

    IEnumerator MainLoop()
    {
        while (true)
        {
            SetWalkingAnim(true);
            yield return MoveToPosition(PickPoint());
            
            SetWalkingAnim(false);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(Random.Range(WaitTime.x, WaitTime.y));
        }
    }

    IEnumerator MoveToPosition(Vector2 point)
    {
        float GiveUpTimer = 0f;
        
        while (Vector2.Distance(transform.position, point) > .1f && GiveUpTimer < GiveUpTime)
        {
            Vector2 dir = (point - (Vector2)transform.position).normalized;
            rb.velocity = (Vector3)(dir * walkspeed);

            GiveUpTimer += Time.deltaTime;
            yield return null;
        }
    }

    private void SetWalkingAnim(bool enabled)
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", enabled);
        }
    }
}

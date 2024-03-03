using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAirplane : MonoBehaviour
{
    public float hitForce = 30f;

    public float cdTime = 1f;
    private float timer = 0f;

    public Rigidbody2D rb;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {
        RotateToForward();
    }

    private void RotateToForward()
    {

        Vector2 MoveDirection = rb.velocity.normalized;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, MoveDirection);
        transform.rotation = toRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timer > 0f)
            {
                return;
            }
            
            Launch();
        }
    }

    private void Launch()
    {
        timer = cdTime;

        // Calculate Angle
        Vector3 Dir = -(playerTransform.position - transform.position).normalized;
        rb.AddForce(hitForce * Dir);

    }
}

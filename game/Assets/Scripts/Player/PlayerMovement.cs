using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float rotationSpeed = 180.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Graphics direction
        // Determine which direction to rotate towards
        Vector2 targetDirection = new Vector3 (horizontal, vertical);
        float inputMagnitude = Mathf.Clamp01(targetDirection.magnitude);
        targetDirection.Normalize();

        //transform.Translate(targetDirection * runSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (targetDirection != Vector2.zero )
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(horizontal, vertical).normalized;
        body.velocity = movementVector * runSpeed;
    }
}

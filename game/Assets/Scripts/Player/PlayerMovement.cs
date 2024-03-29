using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public PlayerHealth playerHealth;

    // input Vectors
    [HideInInspector] public Vector2 inputVector;

    public float baseMoveSpeed = 20.0f;
    public float activeMoveSpeed = 20.0f;
    private List<float> moveSpeedModifers = new List<float>();

    public float rotationSpeed = 180.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CalculateMoveSpeed();


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (playerHealth.isDead)
        {
            horizontal = 0f;
            vertical = 0f;
        }

        inputVector = new Vector2(horizontal, vertical).normalized;

        // Graphics direction
        // Determine which direction to rotate towards
        Vector2 targetDirection = inputVector;
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
        Vector2 movementVector = inputVector;
        body.velocity = movementVector * activeMoveSpeed;
    }

    private void CalculateMoveSpeed()
    {
        activeMoveSpeed = baseMoveSpeed;

        foreach (float mod in moveSpeedModifers)
        {
            activeMoveSpeed *= mod;
        }
    }

    public void ChangeModifier(bool add, float Modifier)
    {
        if (add)
        {
            moveSpeedModifers.Add(Modifier);
        }
        else
        {
            moveSpeedModifers.Remove(Modifier);
        }
    }
}

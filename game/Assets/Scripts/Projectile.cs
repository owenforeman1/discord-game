using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb;

    public bool followPlayer;

    public float speed = 20f;

    Transform PlayerTransform;

    public Sprite DeathIcon;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SetPath();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPath(float angleOffset = 0f)
    {
        AimAtPlayer(angleOffset);
    }

    private void AimAtPlayer(float angleOffset)
    {
        // Go to player
        Vector2 MoveDirection = (PlayerTransform.position - transform.position).normalized;
        rb.velocity = speed * MoveDirection;

        RotateToForward();

        if (angleOffset != 0f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + angleOffset);

            Vector2 newDir = transform.up;
            rb.velocity = speed * newDir;
        }
    }

    private void RotateToForward()
    {
        // Rotates the object so the top is the direction the object is moving

        Vector2 MoveDirection = rb.velocity.normalized;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, MoveDirection);
        transform.rotation = toRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetHit(DeathIcon);
                Destroy(gameObject);
            }

            if (collision.tag == "Wall")
            {
                //GameObject.FindAnyObjectByType<SoundManager>().Play("hitsound");
                Destroy(gameObject);
            }
        }
    }
}

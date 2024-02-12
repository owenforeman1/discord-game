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

    public DamageType ProjectileType = DamageType.None;

    Transform PlayerTransform;

    public Sprite DeathIcon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        MoveToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        // Go to player
        Vector2 MoveDirection = (PlayerTransform.position - transform.position).normalized;
        rb.velocity = speed * MoveDirection;

        // Rotate Direction
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, MoveDirection);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = toRotation;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetHit(ProjectileType, DeathIcon);
                Destroy(gameObject);
            }

            if (collision.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}

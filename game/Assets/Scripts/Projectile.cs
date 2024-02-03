using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb;

    public float speed = 20f;

    public DamageType ProjectileType = DamageType.None;

    Transform PlayerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        // Go to player
        Vector2 MoveDirection = (PlayerTransform.position - transform.position).normalized;
        rb.velocity = speed * MoveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetHit(ProjectileType);
                Destroy(gameObject);
            }
        }
    }
}

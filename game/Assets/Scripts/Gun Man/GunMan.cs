using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMan : MonoBehaviour
{
    [Header("Serialize")]
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform GunLocation1;
    [SerializeField]
    private Transform GunLocation2;

    private Transform playertransform;

    [Header("Stats")]
    public float attackCD = 8f;
    private float attackCDTimer = 0;

    public float attackRange = 20f;


    private void Start()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If Player in range
        if (Vector2.Distance(transform.position, playertransform.position) < attackRange)
        {
            AttackCycle();
        }

    }

    private void AttackCycle()
    {
        attackCDTimer -= Time.deltaTime;
        if (attackCDTimer < 0)
        {
            animator.Play("Fire");
            attackCDTimer = attackCD;
        }
    }

    public void Fire()
    {
        // Releases 2 bullets
        // Called By the animator
        Instantiate(Bullet, GunLocation1.position, Quaternion.identity);
        Instantiate(Bullet, GunLocation2.position, Quaternion.identity);

    }
}

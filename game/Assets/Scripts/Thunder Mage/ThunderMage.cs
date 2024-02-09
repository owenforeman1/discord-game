using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMage : MonoBehaviour
{
    [Header("Serialize")]
    [SerializeField]
    private GameObject ThunderBolt;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform projectileSpawnLocation;


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
        attackCDTimer -= Time.deltaTime;
        // If Player in range
        if (Vector2.Distance(transform.position, playertransform.position) < attackRange)
        {
            AttackCycle();
        }

    }

    private void AttackCycle()
    {

        if (attackCDTimer < 0)
        {
            animator.Play("attack");
            attackCDTimer = attackCD;
        }
    }

    // Called By the animator
    public void Fire()
    {
        
        Instantiate(ThunderBolt, projectileSpawnLocation.position, Quaternion.identity);

        // Play Sound
        //GameObject.FindAnyObjectByType<SoundManager>().Play("gunsound");

    }
}

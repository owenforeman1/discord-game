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

    [Header("Stats")]
    public float attackCD = 8f;
    private float attackCDTimer = 0;


    // Update is called once per frame
    void Update()
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

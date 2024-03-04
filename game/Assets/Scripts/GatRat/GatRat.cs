using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatRat : MonoBehaviour
{
    public float fireRange;

    public float fireCD;
    private float timer;

    private Transform playerTransform;

    [SerializeField] private MiniGunEmitter emitter;
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer < 0f && Vector2.Distance(playerTransform.position, transform.position) < fireRange)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        animator.SetBool("isFiring", true);
        timer = fireCD;
        yield return StartCoroutine(emitter.Fire());

        animator.SetBool("isFiring", false);

    }
}

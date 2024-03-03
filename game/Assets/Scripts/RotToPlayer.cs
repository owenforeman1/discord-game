using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotToPlayer : MonoBehaviour
{
    // Simple: Look at player
    Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = (playerTransform.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, lookDir);
        transform.rotation = toRotation;
    }
}

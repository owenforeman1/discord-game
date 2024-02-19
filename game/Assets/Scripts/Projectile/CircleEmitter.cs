using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEmitter : MonoBehaviour
{
    public float angleRange = 360f;
    public int amount;

    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Fire()
    {
        int i = 0;
        // Starting offset
        float newAngle = -angleRange/2;
        float angleIncrement = angleRange/ amount;

        while (i < amount)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            newProjectile.GetComponent<Projectile>().SetPath(newAngle);

            newAngle += angleIncrement;

            i++;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmitter : MonoBehaviour
{
    public Vector2 EmitTimeMinMax = new Vector2(3f, 5f);

    public float emitTimer;

    public List<GameObject> possibleprojectiles = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        emitTimer -= Time.deltaTime;

        if(emitTimer <= 0)
        {
            Shoot();

            emitTimer = Random.Range(EmitTimeMinMax.x, EmitTimeMinMax.y);
        }
    }

    private void Shoot()
    {
        Instantiate(possibleprojectiles[Random.Range(0, possibleprojectiles.Count)], transform.position, Quaternion.identity);
    }
}

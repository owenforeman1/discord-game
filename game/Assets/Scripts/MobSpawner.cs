using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject Mob;

    public Vector2 SpawnTimeMinMax = new Vector2(3f, 5f);
    float spawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(SpawnTimeMinMax.x, SpawnTimeMinMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(Mob, transform.position, Quaternion.identity);
        spawnTimer = Random.Range(SpawnTimeMinMax.x, SpawnTimeMinMax.y);
    }
}

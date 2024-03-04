using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmitter : MonoBehaviour
{
    public Vector2 EmitTimeMinMax = new Vector2(3f, 5f);

    public float emitTimer;

    public List<GameObject> possibleprojectiles = new List<GameObject>();

    public Transform emitZone;

    public bool autonomous = true;

    public string soundName = "";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autonomous)
        {
            emitTimer -= Time.deltaTime;

            if (emitTimer <= 0)
            {
                Fire();

                emitTimer = Random.Range(EmitTimeMinMax.x, EmitTimeMinMax.y);
            }
        }

    }

    public void Fire()
    {
        if(emitZone != null)
        {
            Instantiate(possibleprojectiles[Random.Range(0, possibleprojectiles.Count)], emitZone.position, Quaternion.identity);
        }
        else
        {
            Instantiate(possibleprojectiles[Random.Range(0, possibleprojectiles.Count)], transform.position, Quaternion.identity);
        }

        if (soundName != "")
        {
            FindAnyObjectByType<SoundManager>().Play(soundName);
        }
       
    }
}

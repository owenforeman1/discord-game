using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBomb : MonoBehaviour
{
    public float timeToExplode = 3f;
    private float timer;

    public string soundName = "";

    public CircleEmitter emitter;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToExplode)
        {
            if (soundName != "")
            {
                FindAnyObjectByType<SoundManager>().Play(soundName);
            }

            emitter.Fire();
            Destroy(gameObject);
        }
    }
}

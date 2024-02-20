using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunEmitter : MonoBehaviour
{

    public float angle = 15f;
    public Vector2 inbetweenTime = new Vector2(.1f, 1f);
    public float fireTime = 3f;
    public float cooldown = 5f;

    public GameObject projectile;

    public string soundName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CycleFire());
    }

    IEnumerator CycleFire()
    {
        while (true)
        {
            yield return Fire();
            yield return new WaitForSeconds(cooldown);
        }
    }


    IEnumerator Fire()
    {
        float fireTimer = 0f;


        while (fireTimer < fireTime)
        {
            float time1 = Time.time;
            
            
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            float randomAngle = Random.Range(-angle/2, angle/2);
            newProjectile.GetComponent<Projectile>().SetPath(randomAngle);

            // Play Sound
            GameObject.FindAnyObjectByType<SoundManager>().Play(soundName);

            yield return new WaitForSeconds(Random.Range(inbetweenTime.x, inbetweenTime.y));


            fireTimer += Time.time - time1;
        }
    }
}

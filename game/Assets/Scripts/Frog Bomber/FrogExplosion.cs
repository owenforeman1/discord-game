using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogExplosion : MonoBehaviour
{
    public List<GameObject> Limbs = new List<GameObject>();

    public float activeFrames = 20f / 60f;

    private void Start()
    {
        Explode();
    }

    private void Explode()
    {
        foreach (GameObject Limb in Limbs)
        {
            Quaternion randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));

            GameObject newLimb = Instantiate(Limb, transform.position, randomAngle);

            newLimb.GetComponent<FrogLimb>().GoCrazy();
        }

        StartCoroutine(HitboxAndDestroy());
    }

    IEnumerator HitboxAndDestroy()
    {
        
        yield return new WaitForSeconds(activeFrames);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetHit(DamageType.Spike);
        }
    }
}

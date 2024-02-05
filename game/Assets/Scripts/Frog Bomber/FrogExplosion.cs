using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogExplosion : MonoBehaviour
{
    public List<GameObject> Limbs = new List<GameObject>();
    
    private void Explode()
    {
        foreach (GameObject Limb in Limbs)
        {
            Quaternion randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));

            GameObject newLimb = Instantiate(Limb, transform.position, randomAngle);

            //newLimb.GetComponent<>
        }
    }
}

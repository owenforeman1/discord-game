using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBoss : MonoBehaviour
{
    public ProjectileEmitter basicEmitter;
    public MiniGunEmitter miniGunEmitter;

    public Sprite deathRecapIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loop()
    {
        // The Boss rotates bewteen the attacks randomly choosing the next one
        // Each attack has a weight of being picked
        // Attacks used recently are less likely to occur

        
        while (true)
        {
            
            
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerHealth>().GetHit(deathRecapIcon);
        }
    }
}

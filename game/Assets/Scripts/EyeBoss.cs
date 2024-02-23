using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class EyeBoss : MonoBehaviour
{
    public ProjectileEmitter basicEmitter;
    public MiniGunEmitter miniGunEmitter;

    public Sprite deathRecapIcon;

    enum BossAttack {SingleWave, MiniGun, Explosive}

    // Stores attack and weighting
    private Dictionary<BossAttack, int> BossAttacks = new Dictionary<BossAttack, int>()
    { 
        {BossAttack.SingleWave, 1},
        {BossAttack.MiniGun, 1},
        {BossAttack.Explosive, 1}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Loop());
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
            BossAttack ChosenAttack = ChooseAttack();

            yield return null;
        }
    }

    private BossAttack ChooseAttack()
    {
        BossAttack nextAttack = BossAttack.SingleWave;


        int sum = 0;
        foreach (KeyValuePair<BossAttack, int> attack in BossAttacks)
        {
            // do something with entry.Value or entry.Key
            sum += attack.Value;
        }
        int chosenValue = Random.Range(0, sum);
        sum = 0;
        
        foreach (KeyValuePair<BossAttack, int> attack in BossAttacks)
        {
            // do something with entry.Value or entry.Key
            sum += attack.Value;
            if (sum <= chosenValue)
            {
                nextAttack = attack.Key;
                break;
            }
        }

        BossAttacks[nextAttack] = 0;

        foreach (KeyValuePair<BossAttack, int> attack in BossAttacks)
        {
            BossAttacks[attack.Key] += 1;
        }


        return nextAttack;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerHealth>().GetHit(deathRecapIcon);
        }
    }
}

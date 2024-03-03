using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EyeBossAttacks : MonoBehaviour
{
    public ProjectileEmitter basicEmitter;
    public ProjectileEmitter bombEmitter;
    public MiniGunEmitter miniGunEmitter;

    public Sprite deathRecapIcon;

    [Header("TimeConfig")]
    public float attackCD;
    public float singlewaveCD = .8f;

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
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        // The Boss rotates bewteen the attacks randomly choosing the next one
        // Each attack has a weight of being picked
        // Attacks used recently are less likely to occur


        while (true)
        {
            // Pick Attack
            BossAttack ChosenAttack = ChooseAttack();
            // Use attack
            yield return DoAttack(ChosenAttack);
            // Wait
            yield return new WaitForSeconds(attackCD);
        }
    }

    IEnumerator DoAttack(BossAttack ChosenAttack)
    {
        switch (ChosenAttack)
        {
            case BossAttack.SingleWave:
                yield return SingleWaveAttack();
                break;
            case BossAttack.MiniGun:
                yield return MiniGunAttack();
                break;
            case BossAttack.Explosive:
                yield return ExplosiveAttack();
                break;
            default:
                print("Not a valid attack");
                break;
        }
    }

    IEnumerator SingleWaveAttack()
    {
        basicEmitter.Fire();
        yield return new WaitForSeconds(singlewaveCD);
        basicEmitter.Fire();
        yield return new WaitForSeconds(singlewaveCD);
        basicEmitter.Fire();
    }

    IEnumerator MiniGunAttack()
    {
        yield return miniGunEmitter.Fire();
    }

    IEnumerator ExplosiveAttack()
    {
        bombEmitter.Fire();

        yield return new WaitForSeconds(3f);
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
            if (chosenValue < sum)
            {
                nextAttack = attack.Key;
                break;
            }
        }

        BossAttacks[nextAttack] = 0;

        foreach (KeyValuePair<BossAttack, int> attack in BossAttacks.ToList())
        {
            BossAttacks[attack.Key] = attack.Value + 1;
        }


        return nextAttack;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBody"))
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<PlayerHealth>().GetHit(deathRecapIcon);
        }
    }
}

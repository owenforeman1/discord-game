using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EyeBoss : MonoBehaviour
{

    public int hp = 3;

    public SpriteRenderer EyeSprite;

    public Color NormalColor;
    public Color HitColor;

    public float flashTime;

    public int flashes = 3;

    public BossFightManager BossFightManager;

    public float invincTime = 1f;
    private bool isImmune = false;

    public List<string> TakeDamageSoundNames = new List<string>();

    private bool isDead;

    private void Update()
    {
        if (hp <= 0 && !isDead)
        {
            StartCoroutine(OnBossDeath());
        }
    }

    public void TakeHit()
    {
        if (isDead) { return; }
        if (isImmune) { return; }

        hp -= 1;

        StartCoroutine(SetImmuneTimer());
        StartCoroutine(OnTakeHit());
        
    }

    IEnumerator OnBossDeath()
    {
        isDead = true;
        // Freeze Player

        // Play Shaking Anim

        BossFightManager.FightWon();
        yield break;

    }

    IEnumerator SetImmuneTimer()
    {
        isImmune = true;
        yield return new WaitForSeconds(invincTime);
        isImmune = false;
    }

    IEnumerator OnTakeHit()
    {
        // Play Sound
        FindObjectOfType<SoundManager>().Play(TakeDamageSoundNames[Random.Range(0, TakeDamageSoundNames.Count)]);
        
        for (int i = 0; i < flashes; i++)
        {
            yield return FadeColor(EyeSprite, NormalColor, HitColor, flashTime);
            yield return FadeColor(EyeSprite, HitColor, NormalColor, flashTime);
        }

        BossFightManager.NewAirplaneSet();
    }

    IEnumerator FadeColor(SpriteRenderer sprite, Color startColor, Color endColor, float timeDuration)
    {

        float timer = 0f;
        float ratio;

        // Fade in
        while (timer < timeDuration)
        {
            ratio = timer / timeDuration;


            sprite.color = Color.Lerp(startColor, endColor, ratio);
            timer += Time.deltaTime;

            yield return null;
        }

        sprite.color = endColor;
    }
}

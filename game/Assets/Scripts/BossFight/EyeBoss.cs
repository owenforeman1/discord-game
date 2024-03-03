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

    private void Start()
    {
        StartCoroutine(OnTakeHit());
    }

    public void TakeHit()
    {
        StartCoroutine(OnTakeHit());
    }

    IEnumerator OnTakeHit()
    {
        for (int i = 0; i < flashes; i++)
        {
            yield return FadeColor(EyeSprite, NormalColor, HitColor, flashTime);
            yield return FadeColor(EyeSprite, HitColor, NormalColor, flashTime);
        }
        
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

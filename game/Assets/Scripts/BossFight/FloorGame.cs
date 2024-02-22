using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGame : MonoBehaviour
{

    public List<GameObject> Floors = new List<GameObject>();

    public float timeToChangeColor = 3f;
    public float activeFloorTime = 3f;

    // How long between each attack
    public float floorChangeCoolDown = 4f;

    public float fadeOutTime = .5f;

    public Color indicatorColor;
    public Color killColor;
    public Color defaultColor;

    // Randomly picks 1 or 2 floor to light up and kill player if they stand on it
    // It fades to the indicatorColor then slams to the killColor when active

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            int activeFloorsAmount = 1;

            // 50% chance to light up 2 floors
            if (Random.Range(0, 2) == 0)
            {
                activeFloorsAmount = 2;
            }

            // Pick Random Floors
            int i = 0;
            List<int> possibleIndexs = new List<int> {0, 1, 2};
            List<int> indexs = new List<int>();
            while (i < activeFloorsAmount)
            {
                int choosenIndex = possibleIndexs[Random.Range(0, possibleIndexs.Count)];
                possibleIndexs.Remove(choosenIndex);
                indexs.Add(choosenIndex);

                i++;
            }

            // Light up each floor
            i = 0;
            while (i < activeFloorsAmount)
            {
                if (i + 1 == activeFloorsAmount)
                {

                    // If last floor to light up then wait for it to finish
                    yield return LightUpFloor(Floors[indexs[i]]);
                }
                else
                {

                    StartCoroutine(LightUpFloor(Floors[indexs[i]]));
                }

                i++;
            }


            yield return new WaitForSeconds(floorChangeCoolDown);

            yield return null;
        }
    }

    IEnumerator LightUpFloor(GameObject floor)
    {
        Tilemap tilemap = floor.GetComponent<Tilemap>();

        // Fade in
        yield return FadeTilemapColor(tilemap, defaultColor, indicatorColor, timeToChangeColor);
        // slam the kill color
        tilemap.color = killColor;

        // Hold for time its active
        yield return new WaitForSeconds(activeFloorTime);
        
        // Fade out
        yield return FadeTilemapColor(tilemap, killColor, defaultColor, fadeOutTime);

    }

    IEnumerator FadeTilemapColor(Tilemap tilemap, Color startColor, Color endColor, float timeDuration)
    {

        float timer = 0f;
        float ratio;

        // Fade in
        while (timer < timeDuration)
        {
            ratio = timer / timeDuration;


            tilemap.color = Color.Lerp(startColor, endColor, ratio);
            timer += Time.deltaTime;

            yield return null;
        }

        tilemap.color = endColor;
    }
}

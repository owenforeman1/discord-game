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


    // Start is called before the first frame update
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
                //print(Floors[i]);
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


        float timer = 0f;
        float ratio = 0f;
        
        // Fade in
        while (timer < timeToChangeColor)
        {
            ratio = timer / timeToChangeColor;


            floor.GetComponent<Tilemap>().color = Color.Lerp(Color.white, Color.red, ratio);
            timer += Time.deltaTime;

            yield return null;
        }

        floor.GetComponent<Tilemap>().color = Color.red;

        yield return new WaitForSeconds(activeFloorTime);

        timer = 0f;
        timer = 0f;
        // Fade out
        while (timer < fadeOutTime)
        {
            ratio = timer / fadeOutTime;


            floor.GetComponent<Tilemap>().color = Color.Lerp(Color.red, Color.white, ratio);
            timer += Time.deltaTime;

            yield return null;
        }

        floor.GetComponent<Tilemap>().color = Color.white;

    }
}

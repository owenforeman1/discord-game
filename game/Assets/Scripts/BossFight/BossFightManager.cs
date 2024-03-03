using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour
{
    public GameObject Envelope;
    public GameObject Merchant;

    public Vector2 xRange;
    public Vector2 yRange;
    public float minDistanceFromCenter;

    public string EndScreenName = "EndScreen";
    // Start is called before the first frame update
    void Start()
    {
        NewAirplaneSet();
    }


    public void FightWon()
    {
        SceneManager.LoadScene(EndScreenName, LoadSceneMode.Single);
    }

    public void NewAirplaneSet()
    {
       // Spawns a new envelop
       // Moves the Merchant
        
        Instantiate(Envelope, PickLocation(), Quaternion.identity);

        Merchant.transform.position = PickLocation();
        Merchant.GetComponent<Merchant>().ReadyForNextEnvelop();
    }

    private Vector2 PickLocation()
    {
        float randomX = Random.Range(xRange.x, xRange.y);


        float randomY = Random.Range(yRange.x, yRange.y);

        Vector2 Location = new Vector2(randomX, randomY);

        if ((Vector2.Distance(Location, Vector2.zero) > minDistanceFromCenter))
        {
            return Location;
        }
        else
        {
            return PickLocation();
        }


    }
}

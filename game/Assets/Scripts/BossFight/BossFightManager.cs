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
        if(Random.Range(0, 2) == 0)
        {
            randomX = -randomX;
        }

        float randomY = Random.Range(yRange.x, yRange.y);
        if (Random.Range(0, 2) == 0)
        {
            randomY = -randomY;
        }

        return new Vector2(randomX, randomY);

    }
}

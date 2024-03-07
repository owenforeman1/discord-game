using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBossMovement : MonoBehaviour
{

    // Picks Locations around the player
    // Slerps to that location
    // Stays there for awhile
    // Repeat

    Transform playerTransform;
    public float waitTime = 5f;
    public float distanceFromPlayerX = 5f;
    public float distanceFromPlayerY = 5f;

    private Vector2 travelVel = Vector2.zero;

    private List<Vector2> possibleOffsets = new List<Vector2>();

    [SerializeField] private EyeBoss EyeBoss;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        possibleOffsets.Add(new Vector2(distanceFromPlayerX, 0f));
        possibleOffsets.Add(new Vector2(-distanceFromPlayerX, 0f));
        possibleOffsets.Add(new Vector2(0f, distanceFromPlayerY));
        possibleOffsets.Add(new Vector2(0f, -distanceFromPlayerY));
        possibleOffsets.Add(new Vector2(distanceFromPlayerX, distanceFromPlayerY));
        possibleOffsets.Add(new Vector2(-distanceFromPlayerX, distanceFromPlayerY));
        possibleOffsets.Add(new Vector2(distanceFromPlayerX, -distanceFromPlayerY));
        possibleOffsets.Add(new Vector2(-distanceFromPlayerX, -distanceFromPlayerY));


        StartCoroutine(Loop());

    }

    IEnumerator Loop()
    {
        while (true)
        {
            if (EyeBoss.isDead) { break; }

            yield return MoveToLocation();

            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveToLocation()
    {
        Vector3 startPos = transform.position;
        Vector3 nextPos = playerTransform.position + (Vector3)possibleOffsets[Random.Range(0, possibleOffsets.Count)];
        nextPos = new Vector3(nextPos.x, nextPos.y, 0f);
        
        float timer = 0f;
        
        while (Vector2.Distance(nextPos, transform.position) > .1f)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.SmoothDamp(transform.position, nextPos, ref travelVel, .3f, 20f);
            //transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

            if (EyeBoss.isDead) { break; }

            yield return null;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogLimb : MonoBehaviour
{

    public Rigidbody2D rb;

    public Vector2 SpeedRange = new Vector2(5f, 15f);
    public Vector2 TorqueRange = new Vector2(-720f, 720f);

    public void GoCrazy()
    {

        Vector2 RandomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = RandomDirection * Random.Range(SpeedRange.x, SpeedRange.y);

        rb.angularVelocity = Random.Range(TorqueRange.x, TorqueRange.y);
    }

}

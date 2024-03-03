using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public Animator Animator;

    public GameObject paperAirplane;

    public Transform paperAirplaneSpawnLocation;


    private void Start()
    {
        Animator.SetBool("wantEnvelope", true);
    }

    public void ReadyForNextEnvelop()
    {
        Animator.SetBool("wantEnvelope", true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Envelope envelope = FindObjectOfType<Envelope>();

            if (envelope == null) { return; }

            if (envelope.isEquiped)
            {
                EnvelopeTurnIn(envelope);
            }
        }
    }

    public void GiveAirplane()
    {
        // Called By animator helper
        Instantiate(paperAirplane, paperAirplaneSpawnLocation.position, Quaternion.identity);

    }

    private void EnvelopeTurnIn(Envelope envelope)
    {
        envelope.TurnInEnvelope();

        Animator.SetBool("wantEnvelope", false);

    }
}

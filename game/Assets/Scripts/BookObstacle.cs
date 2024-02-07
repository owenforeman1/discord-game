using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObstacle : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    public float moveSpeed = 8f;

    public Sprite DeathIcon;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToPosition1());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetHit(DamageType.Spike, DeathIcon);
        }
    }

    IEnumerator MoveToPosition1()
    {
        while (Vector2.Distance(pos1.position, transform.position) > .1f)
        {
            Vector2 dir = (pos1.position - transform.position).normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(MoveToPosition2());
    }
    IEnumerator MoveToPosition2()
    {
        while (Vector2.Distance(pos2.position, transform.position) > .1f)
        {
            Vector2 dir = (pos2.position - transform.position).normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(MoveToPosition1());
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeBossHitBox : MonoBehaviour
{
    public EyeBoss EyeBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PaperAirplane>())
        {
            Destroy(collision.gameObject);
            EyeBoss.TakeHit();
        }
    }
}

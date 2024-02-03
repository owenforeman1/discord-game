using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionPrayer : MonoBehaviour
{
    public enum Protection
    {
        None,
        Lazer,
        Bullet,
        Spike
    }

    // Start is called before the first frame update
    [SerializeField]
    private GameObject ProtectFromLazer;
    [SerializeField]
    private GameObject ProtectFromBullet;
    [SerializeField]
    private GameObject ProtectFromSpike;

    public Protection Prayer = Protection.None;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        DisplayPrayer();
    }

    private void CheckInput()
    {
        if (Input.GetKey("1"))
        {
            Prayer = Protection.Lazer;
            return;
        }
        else if (Input.GetKey("2"))
        {
            Prayer = Protection.Bullet;
            return;
        }
        else if (Input.GetKey("3"))
        {
            Prayer = Protection.Spike;
            return;
        }

        Prayer = Protection.None;
    }

    private void DisplayPrayer()
    {
        ProtectFromLazer.SetActive(false);
        ProtectFromBullet.SetActive(false);
        ProtectFromSpike.SetActive(false);

        switch (Prayer)
        {
            case Protection.Lazer:
                ProtectFromLazer.SetActive(true);
                break;

            case Protection.Bullet:
                ProtectFromBullet.SetActive(true);
                break;

            case Protection.Spike:
                ProtectFromSpike.SetActive(true);
                break;
        }
    }
}

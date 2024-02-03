using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    None,
    Lazer,
    Bullet,
    Spike
}

public class ProtectionPrayer : MonoBehaviour
{
 

    // Start is called before the first frame update
    [SerializeField]
    private GameObject ProtectFromLazer;
    [SerializeField]
    private GameObject ProtectFromBullet;
    [SerializeField]
    private GameObject ProtectFromSpike;

    public DamageType Prayer = DamageType.None;

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
            Prayer = DamageType.Lazer;
            return;
        }
        else if (Input.GetKey("2"))
        {
            Prayer = DamageType.Bullet;
            return;
        }
        else if (Input.GetKey("3"))
        {
            Prayer = DamageType.Spike;
            return;
        }

        Prayer = DamageType.None;
    }

    private void DisplayPrayer()
    {
        ProtectFromLazer.SetActive(false);
        ProtectFromBullet.SetActive(false);
        ProtectFromSpike.SetActive(false);

        switch (Prayer)
        {
            case DamageType.Lazer:
                ProtectFromLazer.SetActive(true);
                break;

            case DamageType.Bullet:
                ProtectFromBullet.SetActive(true);
                break;

            case DamageType.Spike:
                ProtectFromSpike.SetActive(true);
                break;
        }
    }
}

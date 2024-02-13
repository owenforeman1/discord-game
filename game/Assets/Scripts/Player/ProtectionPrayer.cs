using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    None,
    Lazer,
    Bullet,
    Spike,
    All
}

public class ProtectionPrayer : MonoBehaviour
{

    [SerializeField]
    private Shield Shield;


    [SerializeField]
    private GameObject ProtectFromLazer;
    [SerializeField]
    private GameObject ProtectFromBullet;
    [SerializeField]
    private GameObject ProtectFromSpike;

    private Pause pause;

    public DamageType Prayer = DamageType.None;

    void Start()
    {
        pause = GameObject.FindAnyObjectByType<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        DisplayPrayer();

        if (AllowInput())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shield.Toggle();
            }
        }

    }

    private bool AllowInput()
    {
        if (pause != null)
        {
            return !pause.isGamePaused();
        }
        else
        {
            return true;
        }
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

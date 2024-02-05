using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunAnimHelper : MonoBehaviour
{
    public GunMan GunMan;
    public void CallFireGun()
    {
        GunMan.Fire();
    }
}

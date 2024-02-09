using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAttackAnimHelper : MonoBehaviour
{
    public ThunderMage ThunderMage;
    public void CallFire()
    {
        ThunderMage.Fire();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantAnimHelper : MonoBehaviour
{
    public Merchant Merchant;

    public void CallGiveAirplane()
    {
        Merchant.GiveAirplane();
    }
}

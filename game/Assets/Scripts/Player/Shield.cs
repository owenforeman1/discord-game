using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public bool isActive = false;

    private bool inAnim = false;
    
    [Header("Shield Stamina")]
    public float ShieldStaminaMax = 100f;
    [HideInInspector]
    public float ShieldStamina = 100f;
    public float StaminaUsageRate = 100f;
    public float StaminaRechargeRate = 30f;
    public float MinPercentToActivate = .1f;


    private void Update()
    {
        TrackShieldStamina();

    }

    private void TrackShieldStamina()
    {
        if (isActive)
        {
            // Decrement Stam
            ShieldStamina -= StaminaUsageRate*Time.deltaTime;
            if (ShieldStamina <= 0)
            {
                ShieldStamina = 0;
                Deactivate();
            }
        }
        else
        {
            // Increase Stam
            ShieldStamina += StaminaRechargeRate * Time.deltaTime;

            if(ShieldStamina > ShieldStaminaMax)
            {
                ShieldStamina = ShieldStaminaMax;
            }
        }
    }

    public void Toggle()
    {
        if (inAnim){ return; }
        
        if (isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public void Activate()
    {

        if (inAnim) { return; }
        // Cant Activate under certain percent
        if (ShieldStamina/ShieldStaminaMax < MinPercentToActivate)
        {
            return;
        }

        StartCoroutine(ActivateSequence());
    }
    public void Deactivate()
    {

        if (inAnim) { return; }
        StartCoroutine(DeactivateSequence());
    }



    IEnumerator ActivateSequence()
    {
        inAnim = true;
        isActive = true;
        
        animator.Play("ShieldStart");
        // Wait for animation
        yield return new WaitForSeconds(15f / 60f);

        inAnim = false;
        
    }

    IEnumerator DeactivateSequence()
    {
        inAnim = true;
        animator.Play("ShieldEnd");
        // Wait for animation
        yield return new WaitForSeconds(20f / 60f);

        inAnim = false;
        isActive = false;
    }

}

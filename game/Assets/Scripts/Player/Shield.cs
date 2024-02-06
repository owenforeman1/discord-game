using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public bool isActive = false;

    private bool inAnim = false;
    private float AnimTimer;



    private void Update()
    {
        AnimTimer -= Time.deltaTime;
        if (AnimTimer > 0f)
        {
            inAnim = true;
        }
        else
        {
            inAnim = false;
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
        animator.Play("ShieldStart");
        isActive = true;
        inAnim = true;

        AnimTimer = 15f / 60f;
    }
    public void Deactivate()
    {
        animator.Play("ShieldEnd");
        isActive = false;
        inAnim = true;

        AnimTimer = 20f / 60f;
    }
}

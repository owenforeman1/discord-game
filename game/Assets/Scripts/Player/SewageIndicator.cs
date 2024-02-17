using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SewageIndicator : MonoBehaviour
{
    // Makes the player green while on sewage
    public SpriteRenderer spriteRenderer;

    public Color defaultColor = Color.white;
    public Color sewagedColor = Color.green;

    public void UpdateColor(float Timer, float MaxTime)
    {
        float ratio = Timer / MaxTime;

        spriteRenderer.color = Color.Lerp(defaultColor, sewagedColor, ratio);
    }
}

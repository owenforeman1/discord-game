using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SewageIndicator : MonoBehaviour
{
    // Makes the player green while on sewage
    public Color defaultColor = Color.white;
    public Color sewagedColor = Color.green;

    private List<SpriteRenderer> SpriteRenderers = new List<SpriteRenderer>();

    public void UpdateColor(float Timer, float MaxTime)
    {
        if (SpriteRenderers.Count == 0)
        {
            FindSpriteRenderers();
        }
        
        float ratio = Timer / MaxTime;

        foreach (SpriteRenderer spriteRenderer in SpriteRenderers)
        {
            spriteRenderer.color = Color.Lerp(defaultColor, sewagedColor, ratio);
        }

    }

    private void FindSpriteRenderers()
    {
        GameObject[] bodyObjects = GameObject.FindGameObjectsWithTag("PlayerBody");

        foreach (GameObject obj in bodyObjects)
        {
            SpriteRenderers.Add(obj.GetComponent<SpriteRenderer>());
        }
    }
}

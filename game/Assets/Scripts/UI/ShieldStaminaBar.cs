using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldStaminaBar : MonoBehaviour
{
    public Slider slider;
    public Shield Shield;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Shield.ShieldStamina / Shield.ShieldStaminaMax;
    }
}

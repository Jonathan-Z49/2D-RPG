using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    public void useStamina(float i)
    {
        slider.value = slider.value - i;
    }

    public void recoverStamina(float recRate)
    {
        slider.value += recRate * Time.deltaTime;
    }

    public void setMaxStamina(float i)
    {
        slider.maxValue = i;
        slider.value = i;
    }

    public float checkStaminaValue()
    {
        return(slider.value);
    }
}


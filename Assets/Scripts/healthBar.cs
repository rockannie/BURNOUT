using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider energy;
    public Gradient gradient;
    public Image fill;

    public void MaxHealth(int coffee)
    {
        energy.maxValue = coffee;
        energy.value = coffee;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(int coffee)
    {
        energy.value += coffee;
        fill.color = gradient.Evaluate(energy.normalizedValue);
    }

}

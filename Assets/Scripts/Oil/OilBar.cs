using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxOil(int oil)
    {
        slider.maxValue = oil;
        slider.value = oil;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetOil(int oil)
    {
        slider.value = oil;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

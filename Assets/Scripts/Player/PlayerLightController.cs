using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    private Light2D ThisLittleLightOfMine;
    private PlayerOilController OilController;
    public float maxLightRadius = 4, falloff = 9.24f;

    void Awake()
    {
        ThisLittleLightOfMine = GetComponent<Light2D>();
        OilController = GetComponent<PlayerOilController>();
    }

    void FixedUpdate()
    {
        float barPercent = (float)OilController.currOil / (float)OilController.maxOil;
        print(OilController.currOil + " / " + OilController.maxOil + " = " + barPercent);
        ThisLittleLightOfMine.pointLightInnerRadius = (maxLightRadius / 4) - ((1 - barPercent) * Mathf.Pow(maxLightRadius / 4, -1 * ((barPercent * falloff) - 1)));
        ThisLittleLightOfMine.pointLightOuterRadius = maxLightRadius - ((1 - barPercent) * Mathf.Pow(maxLightRadius, -1 * ((barPercent * falloff) - 1)));
    }
}

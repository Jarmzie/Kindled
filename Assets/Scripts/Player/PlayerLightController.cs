﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    private Light2D ThisLittleLightOfMine;
    private PlayerOilController OilController;
    public float maxLightRadius = 4.5f, falloff = 2f; //9.24 for original falloff
    bool dyingFromExplosion = false;

    void Awake()
    {
        ThisLittleLightOfMine = GetComponent<Light2D>();
        OilController = GetComponent<PlayerOilController>();
    }

    void FixedUpdate()
    {
        float barPercent = (float)OilController.currOil / (float)OilController.maxOil;
        if (barPercent > 0)
        {
            ThisLittleLightOfMine.pointLightInnerRadius = (maxLightRadius / 5) - ((1 - barPercent) * Mathf.Pow(maxLightRadius / 4, -1 * ((barPercent * falloff) - 1)));
            ThisLittleLightOfMine.pointLightOuterRadius = maxLightRadius - ((1 - barPercent) * Mathf.Pow(maxLightRadius, -1 * ((barPercent * falloff) - 1)));
        }
        
    }

    public void TurnOnBrights()
    {
        ThisLittleLightOfMine.lightType = Light2D.LightType.Global;
    }

    public void TurnOffBrights()
    {
        ThisLittleLightOfMine.lightType = Light2D.LightType.Point;
    }
}

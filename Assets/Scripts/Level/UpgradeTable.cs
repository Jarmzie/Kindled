using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    public enum UpgradeType
    {
        HealthRegen,     //0, Increase health regen
        LightRadius,     //1, Increase light area
        OilAmount,       //2, ncrease maximum oil
        WalkingSpeed,    //3, Increase walk speed
        OilUseOverTime   //4, Decrease oil use
    }

    public UpgradeType myType;

    private void Awake()
    {
        myType = (UpgradeType)Random.Range(0, 5);
    }
}

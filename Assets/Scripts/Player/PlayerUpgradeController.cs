using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerUpgradeController : MonoBehaviour
{
    public int healthRegenUpgrades = 0, lightRadiusUpgrades = 0, oilAmountUpgrades = 0, walkSpeedUpgrade = 0, oilUseUpgrade = 0;

    public void UpdateMaxOil()
    {
        PlayerOilController temp = GetComponent<PlayerOilController>();
        temp.OilBar.SetMaxOil(temp.maxOil + (25 * oilAmountUpgrades));
    }

    public void UpdateOilUsage()
    {
        PlayerOilController temp = GetComponent<PlayerOilController>();
        temp.CancelInvoke();
        temp.InvokeRepeating("LoseOilOverTime", 0, 1 + (0.1f * oilUseUpgrade));
    }

    public void UpdateLightRadius()
    {
        Light2D temp = GetComponent<Light2D>();
        //Do light shit
    }
}

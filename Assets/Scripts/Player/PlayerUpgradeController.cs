using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

/**
 * I'm gonna be honest...
 * 
 * This is probably the MOST scuffed script in this entire project (This is Joshua from the future. It's not.)
 * 
 * All the upgrades work differently:
 * 
 * healthRegen and walkSpeed are inherently used in their own scripts, so their script reads this script and just uses this number
 * 
 * oilUse resets the repeating method changes the time accordingly
 * 
 * oilAmount uses the built in method from OilBar to change the max directly
 * 
 * lightRadius isn't even technically related to the amount of lightRadiusUpgrades you have, I just add 0.25 to the number every time you get one
 * 
 * I'm wanted to put this here as a way to remember how I implemented all of these upgrades, and as a confession of my shame
 * -Joshua
 **/

public class PlayerUpgradeController : MonoBehaviour
{
    
    public int healthRegenUpgrades = 0, lightRadiusUpgrades = 0, oilAmountUpgrades = 0, walkSpeedUpgrade = 0, oilUseUpgrade = 0;

    public void UpdateMaxOil()
    {
        PlayerOilController temp = GetComponent<PlayerOilController>();
        temp.maxOil = temp.initMaxOil + (50 * oilAmountUpgrades);
        temp.OilBar.SetMaxOil(temp.maxOil);
    }

    public void UpdateOilUsage()
    {
        PlayerOilController temp = GetComponent<PlayerOilController>();
        temp.CancelInvoke();
        temp.InvokeRepeating("LoseOilOverTime", 0, 1 + (0.2f * oilUseUpgrade));
    }

    public void UpdateLightRadius()
    {
        PlayerLightController temp = GetComponent<PlayerLightController>();
        temp.maxLightRadius = temp.maxLightRadius + 1.0f;
    }
}

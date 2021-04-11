using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeController : MonoBehaviour
{
    public int healthRegenUpgrades = 0, lightRadiusUpgrades = 0, oilAmountUpgrades = 0, walkSpeedUpgrade = 0, oilUseUpgrade = 0;

    public void UpdateMaxOil()
    {
        PlayerOilController temp = GetComponent<PlayerOilController>();
        temp.OilBar.SetMaxOil(temp.maxOil + (25 * oilAmountUpgrades));
    }
}

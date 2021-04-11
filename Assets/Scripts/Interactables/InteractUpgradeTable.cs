using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUpgradeTable : Interactable
{
    private UpgradeTable myTable;
    private GameObject myItem;

    private void Start()
    {
        myTable = transform.parent.GetComponent<UpgradeTable>();
        myItem = transform.parent.Find("UpgradeItem").gameObject;
        switch (myTable.myType)
        {
            case UpgradeTable.UpgradeType.HealthRegen:
                InteractMessage = "Health Regen Increase - Press 'E'";
                break;
            case UpgradeTable.UpgradeType.LightRadius:
                InteractMessage = "Light Area Increase - Press 'E'";
                break;
            case UpgradeTable.UpgradeType.OilAmount:
                InteractMessage = "Maximum Oil Increase - Press 'E'";
                break;
            case UpgradeTable.UpgradeType.WalkingSpeed:
                InteractMessage = "Walking Speed Increase - Press 'E'";
                break;
            case UpgradeTable.UpgradeType.OilUseOverTime:
                InteractMessage = "Oil Loss Over Time Decrease  - Press 'E'";
                break;
            default:
                InteractMessage = "Error: No upgrade type";
                break;
        }
    }

    public override IEnumerator OnInteract()
    {
        PlayerUpgradeController temp = GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerUpgradeController>();
        switch (myTable.myType)
        {
            case UpgradeTable.UpgradeType.HealthRegen:
                temp.healthRegenUpgrades++;
                break;
            case UpgradeTable.UpgradeType.LightRadius:
                temp.lightRadiusUpgrades++;
                temp.UpdateLightRadius();
                break;
            case UpgradeTable.UpgradeType.OilAmount:
                temp.oilAmountUpgrades++;
                temp.UpdateMaxOil();
                break;
            case UpgradeTable.UpgradeType.WalkingSpeed:
                temp.walkSpeedUpgrade++;
                break;
            case UpgradeTable.UpgradeType.OilUseOverTime:
                temp.oilUseUpgrade++;
                temp.UpdateOilUsage();
                break;
            default:
                Debug.Log("Error: No upgrade type");
                break;
        }
        Destroy(myItem);
        foreach (GameObject table in GameObject.FindGameObjectsWithTag("UpgradeInteract"))
        {
            Destroy(table);
        }
        yield return null;
    }
}

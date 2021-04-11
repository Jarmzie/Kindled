using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUpgradeTable : Interactable
{
    private UpgradeTable myTable;

    private void Start()
    {
        myTable = transform.parent.GetComponent<UpgradeTable>();
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
        switch (myTable.myType)
        {
            case UpgradeTable.UpgradeType.HealthRegen:
                
                break;
            case UpgradeTable.UpgradeType.LightRadius:
                
                break;
            case UpgradeTable.UpgradeType.OilAmount:
                
                break;
            case UpgradeTable.UpgradeType.WalkingSpeed:
                
                break;
            case UpgradeTable.UpgradeType.OilUseOverTime:
                
                break;
            default:
                Debug.Log("Error: No upgrade type");
                break;
        }
        Destroy(gameObject);
        yield return null;
    }
}

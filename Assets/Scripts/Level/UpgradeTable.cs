using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    [SerializeField]
    Sprite HealthUpgrade, LightUpgrade, OilAmountUpgrade, SpeedUpgrade, OilUseUpgrade;

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
        SpriteRenderer Item = transform.Find("UpgradeItem").GetComponent<SpriteRenderer>();
        switch (myType)
        {
            case UpgradeType.HealthRegen:
                Item.sprite = HealthUpgrade;
                break;
            case UpgradeType.LightRadius:
                Item.sprite = LightUpgrade;
                break;
            case UpgradeType.OilAmount:
                Item.sprite = OilAmountUpgrade;
                break;
            case UpgradeType.WalkingSpeed:
                Item.sprite = SpeedUpgrade;
                break;
            case UpgradeType.OilUseOverTime:
                Item.sprite = OilUseUpgrade;
                break;
            default:
                
                break;
        }
    }
}

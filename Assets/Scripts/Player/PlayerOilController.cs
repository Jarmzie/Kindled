using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerOilController : MonoBehaviour
{
    public int initMaxOil = 200, maxOil = 200, currOil = 200;
    public OilBar OilBar;
    public bool inDark = true;

    private void Start()
    {
        currOil = initMaxOil;
        OilBar.SetMaxOil(initMaxOil);
        InvokeRepeating("LoseOilOverTime", 0, 1);
    }

    private void Update()
    {
        OilBar.SetOil(currOil);
    }

    private void LoseOilOverTime()
    {
        if (inDark)
        {
            currOil--;
        }
    }

    public void LoseOilAmount(int oilAmount)
    {
        currOil -= oilAmount;
    }

    public void GainOilAmount(int oilAmount)
    {
        if (currOil + oilAmount > maxOil)
        {
            currOil = maxOil;
            return;
        }
        currOil += oilAmount;
    }
}

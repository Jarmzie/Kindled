using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOilController : MonoBehaviour
{
    public int maxOil = 200, currOil;
    public OilBar OilBar;
    public bool inDark = true;

    private void Start()
    {
        currOil = maxOil;
        OilBar.SetMaxOil(maxOil);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerOilController : MonoBehaviour
{
    public int initMaxOil = 200, maxOil = 200, currOil = 200;
    public OilBar OilBar;
    public bool  inDark = true, notDying = true;

    private void Start()
    {
        currOil = initMaxOil;
        OilBar.SetMaxOil(initMaxOil);
        InvokeRepeating("LoseOilOverTime", 0, 0.7f);
    }

    private void Update()
    {
        OilBar.SetOil(currOil);
        if (currOil < 1 && notDying)
        {
            notDying = false;
            GetComponent<PlayerDeath>().PlayerDie();
        }
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
        if (currOil - oilAmount < 1)
        {
            currOil = 0;
            return;
        }
        currOil -= oilAmount;
    }

    public void GainOilAmount(int oilAmount)
    {
        if (currOil + oilAmount > maxOil)
        {
            currOil = maxOil;
            return;
        } else if (currOil < 1)
        {
            return;
        }
        currOil += oilAmount;
    }
}

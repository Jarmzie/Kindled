using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOil : MonoBehaviour
{
    public int maxOil = 200;
    public int currentOil;

    public OilBar oilBar;

    // Start is called before the first frame update
    void Start()
    {
        currentOil = maxOil;
        oilBar.SetMaxOil(maxOil);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeOil(5);
        }
    }

    void TakeOil(int burnOil)
    {
        currentOil -= burnOil;
        oilBar.SetOil(currentOil);
    }
}

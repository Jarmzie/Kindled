using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wax : Projectile
{
    private void Awake()
    {
        GeneralSetUp(2f, 0, 0, 10);
        an.SetTrigger(Random.Range(1,5).ToString());
    }
}

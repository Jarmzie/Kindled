using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectile : Projectile
{
    private void Awake()
    {
        GeneralSetUp(3, 0, 0, 5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLanternProjectile : Projectile
{
    void Awake()
    {
        GeneralSetUp(6.0f, 5, 4, 5.0f);
    }
}

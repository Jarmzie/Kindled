using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    void Awake()
    {
        GeneralSetUp(1.0f, 5, 5, 5.0f);
    }
}

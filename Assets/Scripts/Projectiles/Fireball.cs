using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    void Start()
    {
        speed = 1.0f;
        damage = 5;
        cost = 5;
        deathTime = 5.0f;
        GeneralSetUp();
    }
}

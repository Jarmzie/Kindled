using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    void Start()
    {
        speed = 1.0f;
        damage = 5;
        rb = GetComponent<Rigidbody2D>();
        cb = GetComponent<CircleCollider2D>();
        deathTime = 5.0f;
        timeAtLoad = Time.timeSinceLevelLoad;
    }
}

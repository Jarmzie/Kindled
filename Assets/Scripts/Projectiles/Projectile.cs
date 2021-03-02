﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, timeAtLoad, deathTime, timeAlive = 0.0f;
    public int damage;
    public Vector2 directionUnitVector = new Vector2(0.0f, 0.0f);
    public Collider2D cb;
    public Rigidbody2D rb;

    public int GetDamage()
    {
        return damage;
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

    public void TimeDestroy()
    {
        timeAlive = Time.timeSinceLevelLoad - timeAtLoad;
        if (timeAlive > deathTime)
        {
            Destroy(gameObject);
        }
    }

    public virtual void SpecialMove()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
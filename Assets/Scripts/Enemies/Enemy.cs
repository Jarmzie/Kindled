using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage, cost;
    public GameObject myProjectile, player;
    public Transform tf;
    public Animator an;
    public Rigidbody2D rb;

    //It's important to note that most enemies will have a hitbox (for wall collisions), hurtbox (for damage),
    //and probably a player detector (for sensing the player). The hitbox is the collider on the actual enemy
    //while the other colliders have specific children for themselves. The enemy itself needs to be on the "Enemy Hitbox"
    //layer and the child needs to be on the "Enemy Hurtbox" layer. Also, you need to tag the child as "Enemy" as well.

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            DieLOL();
        }
    }

    public void DieLOL()
    {
        Destroy(gameObject);
    }
}

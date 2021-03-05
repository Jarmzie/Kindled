using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage;
    public GameObject myProjectile, player;
    public Transform tf;
    public Animator an;
    public Rigidbody2D rb;

    //It's important to note that most enemies will have a hitbox (for wall collisions), hurtbox (for damage),
    //and probably a player detector (for sensing the player). The hitbox is the collider on the actual enemy
    //while the other colliders have specific children for themselves.
    public Collider2D hurtbox, collisionbox;

    public void SetUpColliders()
    {
       //Don't do shit rn 
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        print(health);
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

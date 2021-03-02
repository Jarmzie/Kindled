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

    //IMPORTANT: For this to assign correctly, you MUST have the hurtbox collider before the collisionbox collider on the enemy, otherwise these are switched
    //Meaning it should look like this:
    //1. Hitbox collider (probably a trigger or something)
    //2. Wall collider (ignored by player)
    //ETC. Any other collider goes after these two
    public Collider2D hurtbox, collisionbox;

    public void SetUpColliders()
    {
        Collider2D[] collidersList = GetComponents<Collider2D>();
        hurtbox = collidersList[0];
        collisionbox = collidersList[1];
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), collisionbox, true);
    }
}

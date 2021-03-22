using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage, cost;
    public GameObject myProjectile, player;
    public Transform tf;
    public SpriteRenderer sr;
    public Animator an;
    public Rigidbody2D rb;

    //It's important to note that most enemies will have a hitbox (for wall collisions), hurtbox (for damage),
    //and probably a player detector (for sensing the player). The hitbox is the collider on the actual enemy
    //while the other colliders have specific children for themselves. The enemy itself needs to be on the "Enemy Hitbox"
    //layer and the child needs to be on the "Enemy Hurtbox" layer. Also, you need to tag the child as "Enemy" as well.

    public void TakeDamage(int damageAmount)
    {
        StartCoroutine(Flashing());
        health -= damageAmount;
        if (health <= 0)
        {
            DieLOL();
        }
    }

    private IEnumerator Flashing()
    {
        Vector4 temp = sr.color;
        sr.color = new Vector4(0.75f, 0, 0, 1);
        yield return new WaitForSeconds(0.25f);
        sr.color = temp;
        yield return null;
    }

    public void DieLOL()
    {
        //player.GetComponent<PlayerAimWeapon>().GiveOil((int)(health * 1.1));
        Destroy(gameObject);
    }

    public void DamagePlayer()
    {
        player.SendMessage("TakeDamage", damage);
    }
}

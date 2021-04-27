using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth, health, damage, cost;
    private bool isFlashing = false;
    public GameObject myProjectile, player;
    public Transform tf;
    public SpriteRenderer sr;
    public Animator an;
    public Rigidbody2D rb;

    //It's important to note that most enemies will have a hitbox (for wall collisions), hurtbox (for damage),
    //and probably a player detector (for sensing the player). The hitbox is the collider on the actual enemy
    //while the other colliders have specific children for themselves. The enemy itself needs to be on the "Enemy Hitbox"
    //layer and the child needs to be on the "Enemy Hurtbox" layer. Also, you need to tag the child as "Enemy" as well.

    protected void GeneralSetUp()
    {
        maxHealth = health;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        an = GetComponent<Animator>();
        player = GameObject.FindWithTag("PlayerLegs");
    }

    public void TakeDamage(int damageAmount)
    {
        StartCoroutine(Flashing());
        health -= damageAmount;
        if (health <= 0)
        {
            DieLOL();
        }
    }

    private IEnumerator Flashing() //This method is literally double the length just to check if it's flashing, there's no better solution
    {
        if (isFlashing)
        {
            yield break;
        }
        isFlashing = true;
        Vector4 temp = sr.color;
        sr.color = new Vector4(0.75f, 0, 0, 1);
        yield return new WaitForSeconds(0.25f);
        sr.color = temp;
        isFlashing = false;
        yield return null;
    }

    public void DieLOL()
    {
        player.GetComponent<PlayerOilController>().GainOilAmount((int)(maxHealth));
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = Vector3.zero;
        }
        transform.Find("Hurtbox").GetComponent<Collider2D>().enabled = false;
        an.SetTrigger("Destroy");
    }

    public void DamagePlayer()
    {
        player.SendMessage("TakeDamage", damage);
    }
}

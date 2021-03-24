using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, timeAtLoad, deathTime, timeAlive = 0.0f;
    public int damage, cost;
    public Vector2 directionUnitVector = new Vector2(0.0f, 0.0f);
    public Animator an;
    public Collider2D cb;
    public Rigidbody2D rb;

    protected void GeneralSetUp()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cb = GetComponent<CircleCollider2D>();
        timeAtLoad = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        TimeDestroy();
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void TimeDestroy()
    {
        timeAlive = Time.timeSinceLevelLoad - timeAtLoad;
        if (timeAlive > deathTime)
        {
            DestroyProjectile();
        }
    }

    public virtual void SpecialMove()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("barrel"))
        {
            rb.velocity = Vector3.zero;
            DestroyProjectile();
        } else if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Player"))
        {
            col.SendMessageUpwards("TakeDamage", damage);
            rb.velocity = Vector3.zero;
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        cb.enabled = false;
        an.SetTrigger("Destroy");
    }
}
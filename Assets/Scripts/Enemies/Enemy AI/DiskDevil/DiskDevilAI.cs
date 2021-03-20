using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskDevilAI : Enemy
{
    bool DVD = true;
    void Start()
    {
        health = 50;
        cost = 2;
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        an = GetComponent<Animator>();
        player = GameObject.Find("Player (Legs)");
        //rb.velocity = Random.insideUnitCircle.normalized * 3;
        rb.velocity = new Vector2(4, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DVD)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = new Vector4(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
        }
    }
}

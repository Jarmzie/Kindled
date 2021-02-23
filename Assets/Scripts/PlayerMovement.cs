using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public bool facingRight = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float velocityX = 0.0f, velocityY = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (velocityX > 0 && !facingRight || velocityX < 0 && facingRight)
        {
            sr.flipX = !sr.flipX;
            facingRight = !facingRight;
        }
    }

    void FixedUpdate()
    {
        velocityX = Input.GetAxis("Horizontal");
        velocityY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(velocityX * speed, velocityY * speed);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    public bool facingRight = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerUpgradeController upgrades;
    public float velocityX = 0.0f, velocityY = 0.0f;

    void Start()
    {
        //This isn't movement stuff but I didn't know where else to put it so it goes here
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        upgrades = GetComponent<PlayerUpgradeController>();
    }

    void Update()
    {
        if (velocityX > 0 && !facingRight || velocityX < 0 && facingRight)
        {
            sr.flipX = !sr.flipX;
            facingRight = !facingRight;
        }

        //THIS IS JUST FOR TESTING, DELETE BEFORE FINAL BUILD!!!
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        velocityX = Input.GetAxis("Horizontal");
        velocityY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(velocityX, velocityY) * speed * (1 + (0.1f * upgrades.walkSpeedUpgrade));

    }

}
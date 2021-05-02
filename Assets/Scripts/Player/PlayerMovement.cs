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
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight || Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            sr.flipX = !sr.flipX;
            facingRight = !facingRight;
        }

        //This keeps throwing errors and it's annoying me
        /*if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")){
            FindObjectOfType<AudioManager>().Plays("PlayerWalk");
        }else if(!Input.GetButtonDown("Horizontal") && (!Input.GetButtonDown("Vertical")))
        {
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
        }*/
           
       
        
        

        //deleted the if statement that closed the game because I created a pause menu
    }

    void FixedUpdate()
    {
        velocityX = Input.GetAxis("Horizontal");
        
        velocityY = Input.GetAxis("Vertical");
        

        rb.velocity = new Vector2(velocityX, velocityY) * speed * (1 + (0.1f * upgrades.walkSpeedUpgrade));
    }

    public void CutsceneMe(bool on)
    {
        enabled = on;
        GetComponent<PlayerAnimation>().enabled = on;
        GetComponent<Animator>().enabled = on;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
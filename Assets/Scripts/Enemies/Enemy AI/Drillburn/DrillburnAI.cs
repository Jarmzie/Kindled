using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DrillburnAI : Enemy
{
    private bool horizontal = true, charging = false;
    private Light2D myLight;
    private const float VIEW_DIST = 1.25f;

    private enum DrillDirection
    {
        Up = 1,
        Down = -1,
        Left = 5,
        Right = -5
    }

    void Awake()
    {
        health = 30;
        cost = 4;
        myLight = GetComponent<Light2D>();
        GeneralSetUp();
        rb.velocity = new Vector2(2, 0); //probably randomize this
    }

    void Update()
    {
        DeathSound();

        if (!charging) //checks if charging
        {
            if (horizontal) //checks direction
            {
                if (Physics2D.Raycast(transform.position, Vector2.up, VIEW_DIST, 1 << 13) || Physics2D.Raycast(transform.position, Vector2.down, VIEW_DIST, 1 << 13)) //finds player
                {
                    if (player.transform.position.y > transform.position.y) //checks if up
                    {
                        an.SetTrigger("SprintDown");
                        StartCoroutine(Charge(DrillDirection.Up));
                    } 
                    else //else down
                    {
                        an.SetTrigger("SprintUp");
                        StartCoroutine(Charge(DrillDirection.Down));
                    }
                }
            }
            else
            {
                if (Physics2D.Raycast(transform.position, Vector2.left, VIEW_DIST, 1 << 13) || Physics2D.Raycast(transform.position, Vector2.right, VIEW_DIST, 1 << 13))
                {
                    if (player.transform.position.x > transform.position.x) //checks if right
                    {
                        an.SetTrigger("SprintRight");
                        StartCoroutine(Charge(DrillDirection.Left));
                    }
                    else //else left
                    {
                        an.SetTrigger("SprintLeft");
                        StartCoroutine(Charge(DrillDirection.Right));
                    }
                }
            }
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        an.SetTrigger("SwitchDirection");
    }

    //It's 4:11 AM, I just programmed this in one sitting wtihout testing and it worked first try and I popped off so hard
    
    private IEnumerator Charge(DrillDirection chaseDirection)
    {
        rb.velocity = Vector2.zero;
        horizontal = !horizontal;
        charging = true;
        FindObjectOfType<AudioManager>().Plays("deez");
        myLight.pointLightInnerRadius = 0.25f;
        myLight.pointLightOuterRadius = 1.25f;
        yield return new WaitForSeconds(1.5f);
        switch (chaseDirection)
        {
            case DrillDirection.Up:
            case DrillDirection.Down:
                rb.velocity = new Vector2(0, (int)chaseDirection) * 5;
                break;
            case DrillDirection.Right:
            case DrillDirection.Left:
                rb.velocity = new Vector2((int)chaseDirection, 0);
                break;
        }
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManager>().Stop("deez");
        Vector2 tempHold = rb.velocity.normalized;
        rb.velocity = Vector2.zero;
        myLight.pointLightInnerRadius = 0;
        myLight.pointLightOuterRadius = 0;
        an.SetTrigger("TireOut"); 
        yield return new WaitForSeconds(3); 
        an.SetTrigger("TireOut");
        rb.velocity = tempHold * 2;
        charging = false;
        yield return null;
    }

    void DeathSound()
    {
        if(health == 0)
        {
            FindObjectOfType<AudioManager>().Stop("deez");
            
        }
    }
}
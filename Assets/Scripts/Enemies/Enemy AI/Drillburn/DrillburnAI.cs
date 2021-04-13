using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillburnAI : Enemy
{
    private bool horizontal = true, charging = false;

    private enum DrillDirection
    {
        Up = 1,
        Down = -1,
        Left = 5,
        Right = -5
    }

    void Awake()
    {
        health = 60;
        cost = 4;
        GeneralSetUp();
        rb.velocity = new Vector2(2, 0); //probably randomize this
    }

    void Update()
    {
        if (!charging) //checks if charging
        {
            if (horizontal) //checks direction
            {
                if (Physics2D.Raycast(transform.position, Vector2.up, 4, 1 << 13) || Physics2D.Raycast(transform.position, Vector2.down, 4, 1 << 13)) //finds player
                {
                    if (player.transform.position.y > transform.position.y) //checks if up
                    {
                        StartCoroutine(Charge(DrillDirection.Up));
                    } 
                    else //else down
                    {
                        StartCoroutine(Charge(DrillDirection.Down));
                    }
                }
            }
            else
            {
                if (Physics2D.Raycast(transform.position, Vector2.left, 4, 1 << 13) || Physics2D.Raycast(transform.position, Vector2.right, 4, 1 << 13))
                {
                    if (player.transform.position.x > transform.position.x) //checks if right
                    {
                        StartCoroutine(Charge(DrillDirection.Left));
                    }
                    else //else left
                    {
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
    //No animations yet tho
    private IEnumerator Charge(DrillDirection chaseDirection)
    {
        rb.velocity = Vector2.zero;
        horizontal = !horizontal;
        charging = true;
        //Get mad
        yield return new WaitForSeconds(1); //mad animation wait
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
        Vector2 tempHold = rb.velocity.normalized;
        rb.velocity = Vector2.zero;
        //an.SetTrigger("FoundLifesManager"); //tired animation to normal animation
        yield return new WaitForSeconds(1); //tired animation wait
        rb.velocity = tempHold * 2;
        charging = false;
        yield return null;
    }
}

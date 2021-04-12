using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorsoAnimation : MonoBehaviour
{
    private Animator an, pan;
    private SpriteRenderer sr, psr;
    string tempName = "", difName = "";
    private bool shooting = false;
    private float shotAngle = 1;
    direction currDirection = direction.Down, lastDirection = direction.Down;

    enum direction
    {
        Up,
        Down,
        Left,
        Right,
        Other
    }

    void Start()
    {
        an = GetComponent<Animator>();
        pan = transform.parent.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        psr = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (psr.flipX != sr.flipX && currDirection != direction.Up && currDirection != direction.Down)
        {
            sr.flipX = psr.flipX;
        }
        if (Input.GetMouseButtonDown(0))
        {
            float temp = Mathf.Rad2Deg * Mathf.Atan2((Input.mousePosition.y - Screen.height / 2), (Input.mousePosition.x - Screen.width / 2));
            if (temp < 0)
            {
                temp = 360 + temp;
            }
            print(temp);
            shotAngle = temp;
            ShootAtDirection();
        }
    }

    void FixedUpdate()
    {
        an.SetFloat("Angle", shotAngle);
        currDirection = findDirection();
        if (currDirection != lastDirection && !shooting)
        {
            if (currDirection == direction.Down)
            {
                an.SetTrigger("Down");
            }
            else if (currDirection == direction.Up)
            {
                an.SetTrigger("Up");
            }
            else if (currDirection == direction.Left || currDirection == direction.Right)
            {
                an.SetTrigger("Side");
            }
            else if (currDirection == direction.Other)
            {
                sr.color = new Vector4(1, 1, 1, 0);
            }
            lastDirection = currDirection;
        } else if (currDirection != lastDirection)
        {
            ShootAtDirection();
            lastDirection = currDirection;
        }
    }

    direction findDirection()
    {
        tempName = pan.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (tempName.Equals("Legs_Down") || tempName.Equals("Legs_Down_Idle"))
        {
            return direction.Down;
        }
        else if (tempName.Equals("Legs_Up") || tempName.Equals("Legs_Up_Idle"))
        {
            return direction.Up;
        }
        else if (tempName.Equals("Legs_Side") || tempName.Equals("Legs_Side_Idle"))
        {
            if (!sr.flipX)
            {
                return direction.Left;
            }
            else
            {
                return direction.Right;
            }
        }
        return direction.Other;
    }

    void ShootAtDirection()
    {
        for (int i = 0; i < 5; i++)
        {
            an.SetLayerWeight(i, 0);
        }
        if (currDirection == direction.Down)
        {
            an.SetLayerWeight(an.GetLayerIndex("ShootingDown"), 1);
        }
        else if (currDirection == direction.Up)
        {
            an.SetLayerWeight(an.GetLayerIndex("ShootingUp"), 1);
        }
        else if (currDirection == direction.Right)
        {
            an.SetLayerWeight(an.GetLayerIndex("ShootingRight"), 1);
        }
        else if (currDirection == direction.Left)
        {
            an.SetLayerWeight(an.GetLayerIndex("ShootingLeft"), 1);
        }
        else if (currDirection == direction.Other)
        {
            shooting = false;
        }
    }
}
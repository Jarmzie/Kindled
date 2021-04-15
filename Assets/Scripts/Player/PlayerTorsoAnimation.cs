using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorsoAnimation : MonoBehaviour
{
    public Animator an, pan;
    private SpriteRenderer sr, psr;
    private GameObject lamp;
    string tempName = "";
    public bool shooting = false;
    public float shotAngle = 1;
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
        lamp = transform.Find("Lantern").gameObject;
    }

    private void Update()
    {
        if ((currDirection == direction.Up || currDirection == direction.Down) && psr.flipX)
        {
            sr.flipX = false;
            psr.flipX = false;
            transform.parent.GetComponent<PlayerMovement>().facingRight = false;
        }
    }

    void FixedUpdate()
    {
        an.SetFloat("Angle", shotAngle);
        currDirection = findDirection();
        lamp.GetComponent<LayerController>().CheckAndSet();
        if (currDirection != lastDirection)
        {
            if (!shooting)
            {
                switch (currDirection)
                {
                    case direction.Down:
                        an.SetTrigger("Down");
                        break;
                    case direction.Up:
                        an.SetTrigger("Up");
                        break;
                    case direction.Left:
                        an.SetTrigger("Side");
                        break;
                    case direction.Right:
                        an.SetTrigger("Right");
                        break;
                    case direction.Other:
                        sr.color = new Vector4(1, 1, 1, 0);
                        break;
                }
                lastDirection = currDirection;
            }
            else
            {
                ShootAtDirection();
                lastDirection = currDirection;
            }
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
            if (!psr.flipX)
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

    public void ShootAtDirection()
    {
        for (int i = 0; i < 5; i++)
        {
            an.SetLayerWeight(i, 0);
        }
        switch (currDirection)
        {
            case direction.Down:
                an.SetLayerWeight(an.GetLayerIndex("ShootingDown"), 1);
                break;
            case direction.Up:
                an.SetLayerWeight(an.GetLayerIndex("ShootingUp"), 1);
                break;
            case direction.Left:
                an.SetLayerWeight(an.GetLayerIndex("ShootingLeft"), 1);
                break;
            case direction.Right:
                an.SetLayerWeight(an.GetLayerIndex("ShootingRight"), 1);
                break;
            case direction.Other:
                shooting = false;
                break;
        }
    }
}
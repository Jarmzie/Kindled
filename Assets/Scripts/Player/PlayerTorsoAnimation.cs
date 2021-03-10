﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorsoAnimation : MonoBehaviour
{
    private Animator an, pan;
    private SpriteRenderer sr, psr;
    string tempName = "", difName = "";

    void Start()
    {
        an = GetComponent<Animator>();
        pan = transform.parent.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        psr = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (psr.flipX != sr.flipX)
        {
            sr.flipX = psr.flipX;
        }
    }

    void FixedUpdate()
    {
        tempName = pan.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (tempName != difName) 
        {
            if (tempName.Equals("Legs_Down") || tempName.Equals("Legs_Down_Idle"))
            {
                print("Down");
                an.SetTrigger("Down");
            } else if (tempName.Equals("Legs_Up") || tempName.Equals("Legs_Up_Idle"))
            {
                print("Up");
                an.SetTrigger("Up");
            } else if (tempName.Equals("Legs_Side") || tempName.Equals("Legs_Side_Idle"))
            {
                print("Side");
                an.SetTrigger("Side");
            } else
            {
                print("Nope lol");
            }
            difName = tempName;
        }
    }
}

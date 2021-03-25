using System.Collections;
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
                an.SetTrigger("Down");
            } else if (tempName.Equals("Legs_Up") || tempName.Equals("Legs_Up_Idle"))
            {
                an.SetTrigger("Up");
            } else if (tempName.Equals("Legs_Side") || tempName.Equals("Legs_Side_Idle"))
            {
                an.SetTrigger("Side");
            }
            else if (tempName.Equals("Player_Death") || tempName.Equals("Invis"))
            {
                sr.color = new Vector4(1, 1, 1, 0);
            }
            difName = tempName;
        }
    }
}

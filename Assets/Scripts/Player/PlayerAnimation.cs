using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator an;
    float velocityX = 0.0f, velocityY = 0.0f;
    private bool buttonsDown = false, horZero = true;

    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //I hate this but I can't think of a better way to do it... so it stays for now for animations
        if (!buttonsDown && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            buttonsDown = true;
        }
        else if (buttonsDown && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            buttonsDown = false;
        }
        //I hate this if statement too but the animatior doesn't have an "equal to" function for floats so I cry
        /*if (horZero && velocityX != 0)
        {
            horZero = false;
        }
        else if (!horZero && velocityX == 0)
        {
            horZero = true;
        }*/
        if (horZero && Input.GetAxisRaw("Horizontal") != 0)
        {
            horZero = false;
        }
        else if (!horZero && Input.GetAxisRaw("Horizontal") == 0)
        {
            horZero = true;
        }
    }

    void FixedUpdate()
    {
        velocityX = Input.GetAxis("Horizontal");
        velocityY = Input.GetAxis("Vertical");
        an.SetFloat("VerticalSpeed", velocityY);
        an.SetFloat("HorizontalSpeed", velocityX);
        an.SetBool("HorizontalZero", horZero);
        an.SetBool("Moving", buttonsDown);
    }
}

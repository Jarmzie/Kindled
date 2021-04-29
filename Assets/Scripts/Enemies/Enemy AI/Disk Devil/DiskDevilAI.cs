using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DiskDevilAI : Enemy
{
    bool DVD = false, checkForAngle = false, blinking = false;
    float currAngle = 0;
    Light2D myLight;
    Coroutine lastRoutine = null;
    void Awake()
    {
        health = 30;
        cost = 2;
        myLight = GetComponent<Light2D>();
        GeneralSetUp();
        StartCoroutine(Readjust());
        //rb.velocity = new Vector2(4, 4);
    }

    private void Update()
    {
        //This is just to reset the angle if the Devil is moving at an annoying angle (basically around the cardinal directions)
        if ((currAngle > 60 || (currAngle < 30 && currAngle > -30) || currAngle < -60) && checkForAngle)
        {
            StartCoroutine(Readjust());
        }
        DeathSound();
    }

    //Resets the angle the Devil is moving at with a cool animation to make it look nicer
    private IEnumerator Readjust()
    {
        checkForAngle = false;
        an.SetTrigger("GetMad");
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        an.SetTrigger("Speen");
        rb.velocity = new Vector2(Mathf.Sin(Mathf.Deg2Rad * (90 * Random.Range(0, 4) + 45) - Random.Range(-10f, 10f)), Mathf.Sin(Mathf.Deg2Rad * (90 * Random.Range(1, 5) + 45) - Random.Range(-10f, 10f))).normalized * 3;
        currAngle = Mathf.Rad2Deg * Mathf.Atan(rb.velocity.y / rb.velocity.x);
        checkForAngle = true;
        yield return null;
    }

    private IEnumerator Blink()
    {
        blinking = true;
        float tempRad = 2;
        myLight.color = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
        for (int i = 0; i < 20; i++)
        {
            myLight.pointLightOuterRadius = tempRad;
            tempRad -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        myLight.pointLightOuterRadius = 0;
        blinking = false;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Plays("WheelBounce");
        sr.flipX = !sr.flipX;
        if (blinking)
        {
            StopCoroutine(lastRoutine);
        }
        lastRoutine = StartCoroutine(Blink());
        if (rb.velocity.x != 0)
        {
            currAngle = Mathf.Rad2Deg * Mathf.Atan(rb.velocity.y / rb.velocity.x);
        } else
        {
            StartCoroutine(Readjust());
        }
        if (DVD)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = new Vector4(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
        }
    }

    void DeathSound()
    {
        if (health == 0)
        {
            FindObjectOfType<AudioManager>().Plays("WheelDeath");
        }
    }
}

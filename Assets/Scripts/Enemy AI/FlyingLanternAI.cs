﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLanternAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    private Animator an;
    private bool playerInRange = false;
    private Vector3 curPlayerPosition;
    public GameObject projectile, player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        an = GetComponent<Animator>();
        curPlayerPosition = player.GetComponent<Transform>().position;
        InvokeRepeating("DecideBehaviour", 1.0f, 3.0f);
    }

    void Update()
    {
        curPlayerPosition = player.GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player") {
            playerInRange = true;
            print("Enter");
        }
    }

    void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            playerInRange = false;
            print("Exit");
        }
    }

    Vector2 findPlayerDirection(Vector3 playerPos, Vector3 myPos)
    {
        Vector2 delta = myPos - playerPos;
        float theta = Mathf.Atan(delta.y / delta.x);
        Vector2 direction = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        if (tf.position.x > playerPos.x)
        {
            direction *= -1;
        }
        return direction;
    }

    Vector2 findPlayerDirection(Vector2 playerPos, Vector2 myPos)
    {
        Vector2 delta = myPos - playerPos;
        float theta = Mathf.Atan(delta.y / delta.x);
        Vector2 direction = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        if (tf.position.x > playerPos.x)
        {
            direction *= -1;
        }
        return direction;
    }

    void DecideBehaviour()
    {
        if (playerInRange) {
            print("Swoop");
            StartCoroutine(SwoopTowardsPlayer(curPlayerPosition));
        } else if (Random.Range(1, 2) == 1) {
            print("Random");
            StartCoroutine(MoveRandomly());
        } else {
            print("Shoot");
            StartCoroutine(ShootProjectile(curPlayerPosition, projectile));
        }
    }

    private IEnumerator ShootProjectile(Vector3 playerPos, GameObject proj)
    {
        an.SetTrigger("WingsDown");
        yield return new WaitForSeconds(0.5f);
        an.SetTrigger("Idle");
        Vector2 sentDirection = findPlayerDirection(playerPos, tf.position);
        GameObject newProj = Instantiate(proj, tf.position, Quaternion.identity);
        //This is entirely temporary, will prbably implement a projectile interface to make a generic script
        newProj.GetComponent<Rigidbody2D>().velocity = sentDirection;
        yield return null;
    }

    private IEnumerator MoveRandomly()
    {
        Vector2 randomDirection = findPlayerDirection(new Vector2(0, 0), Random.insideUnitCircle);
        rb.velocity = randomDirection * 1.5f; //+ new Vector2(0, -2 * Mathf.Sin(i * Mathf.Deg2Rad));
        yield return new WaitForSeconds(1.5f);
        rb.velocity = Vector2.zero;
        yield return null;
    }

    private IEnumerator SwoopTowardsPlayer(Vector3 playerPos)
    {
        an.SetTrigger("WingsUp");
        yield return new WaitForSeconds(0.5f);
        rb.velocity = findPlayerDirection(playerPos, tf.position) * 10;
        for (int i = 0; i < 10; i++)
        {
            rb.velocity -= 0.2f * rb.velocity;
            yield return new WaitForSeconds(0.1f);
        }
        an.SetTrigger("Idle");
        rb.velocity = Vector2.zero;
        yield return null;
    }
}

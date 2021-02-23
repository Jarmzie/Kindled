using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLanternAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    private Animator an;
    private bool playerInRange = false, iamtired = false;
    private Vector3 curPlayerPosition;
    public GameObject projectile, player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        an = GetComponent<Animator>();
        curPlayerPosition = player.GetComponent<Transform>().position;
        InvokeRepeating("DecideBehaviour", 1.0f, 4.0f);
    }

    void Update()
    {
        curPlayerPosition = player.GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    Vector2 findPlayerDirection(Vector3 playerPos)
    {
        Vector2 delta = tf.position - playerPos;
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
            print("Shoot");
            StartCoroutine(ShootProjectile(curPlayerPosition, projectile));
        } else {
            print("Random");
            StartCoroutine(MoveRandomly());
        }
    }

    IEnumerator ShootProjectile(Vector3 playerPos, GameObject proj)
    {
        if (!iamtired) {
            iamtired = true;
            yield return new WaitForSeconds(2);
        }
        iamtired = false;
        Vector2 sentDirection = findPlayerDirection(playerPos);
        GameObject newProj = Instantiate(proj, tf.position, Quaternion.identity);
        //This is entirely temporary, will prbably implement a projectile interface to make a generic script
        newProj.GetComponent<Rigidbody2D>().velocity = sentDirection;
        yield return null;
    }

    IEnumerator MoveRandomly()
    {
        yield return null;
    }

    IEnumerator SwoopTowardsPlayer(Vector3 playerPos)
    {
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour
{
    public bool playerInRange = false;

    public Transform tf;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator an;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       

        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        player = GameObject.Find("Player (Legs)");
        an.SetInteger("Health", 30);
        InvokeRepeating("DecideBehaviour", 5.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private  IEnumerator MoveRandomly()
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



    void DecideBehaviour()
    {
        if (playerInRange)
        {
            StartCoroutine(SwoopTowardsPlayer(player.GetComponent<Transform>().position));
        }
        else 
        {
            StartCoroutine(MoveRandomly());
        }
       
    }

}

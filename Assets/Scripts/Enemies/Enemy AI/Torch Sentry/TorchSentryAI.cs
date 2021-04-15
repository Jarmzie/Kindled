using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSentryAI : Enemy
{
    void Awake()
    {
        health = 30;
        cost = 2;
        //myLight = GetComponent<Light2D>(); //just in case
        GeneralSetUp();
        InvokeRepeating("StartBlasting", 3, 3);
    }

    private void StartBlasting()
    {
        Vector2 eyePos = tf.position + new Vector3(0, 0.4f);
        Vector2 sentDirection = findPlayerDirection(player.transform.position, eyePos);
        GameObject newProj = Instantiate(myProjectile, eyePos, Quaternion.identity);
        newProj.GetComponent<Rigidbody2D>().velocity = sentDirection * newProj.GetComponent<Projectile>().GetSpeed();
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
}

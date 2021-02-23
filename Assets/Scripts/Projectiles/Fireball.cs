using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timeAtLoad, timeAlive = 0.0f;
    public Vector2 direction = new Vector2(0.0f, 0.0f);
    public float speed = 1.0f;
    public int deathTime = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeAtLoad = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        timeAlive = Time.timeSinceLevelLoad - timeAtLoad;
        if (timeAlive > deathTime)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int lanternHealth = 30;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            lanternHealth -= 5;
            if (lanternHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

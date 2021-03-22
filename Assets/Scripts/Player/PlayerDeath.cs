using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public int playerHealth = 3;
    private bool inHitStun = false;
    public GameObject bloodVignette, torso;
    private Image bvsr;

    private void Start()
    {
        bvsr = bloodVignette.GetComponent<Image>();
    }

    IEnumerator TakeDamage (int damage)
    {
        //Check for hitstun
        if (inHitStun)
        {
            yield break;
        }
        inHitStun = true;

        //Subtract health, update blood, check for death
        playerHealth--;
        UpdateBlood();
        if (playerHealth == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            PlayerDie();
        }

        //The rest of this is for the flashing and hitstun reset
        SpriteRenderer temp = GetComponent<SpriteRenderer>(), tempTorso = torso.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 11; i++)
        {
            if(temp.color.a == 0)
            {
                temp.color = new Vector4(1, 1, 1, 1);
                tempTorso.color = new Vector4(1, 1, 1, 1);
            } else
            {
                temp.color = new Vector4(1, 1, 1, 0);
                tempTorso.color = new Vector4(1, 1, 1, 0);
            }
            yield return new WaitForSeconds(0.075f);
        }
        temp.color = new Vector4(1, 1, 1, 1);
        tempTorso.color = new Vector4(1, 1, 1, 1);
        inHitStun = false;
        yield return null;
    }

    private void UpdateBlood()
    {
        if (playerHealth == 2)
        {
            bvsr.color = new Vector4(1, 1, 1, 0.33f);
        }
        else if (playerHealth == 1)
        {
            bvsr.color = new Vector4(1, 1, 1, 0.66f);
        } else
        {
            bvsr.color = new Vector4(1, 1, 1, 0);
        }
    }

    public void PlayerDie()
    {
        print("Player would've died here");
    }
}

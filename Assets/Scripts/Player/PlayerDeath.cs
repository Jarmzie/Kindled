using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int playerHealth = 3;
    public GameObject spawnPoint;
   
    

    void TakeDamage (int damage)
    {
        playerHealth -= 1;
        if (playerHealth == 0)
        {
            gameObject.transform.position = spawnPoint.GetComponent<Transform>().position;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            playerHealth = 3;

            GameObject thePlayer = GameObject.Find("Player (Legs)");
            PlayerAimWeapon playerAimWeapon = thePlayer.GetComponent<PlayerAimWeapon>();
            playerAimWeapon.currentOil = 200;
        }
    }
}

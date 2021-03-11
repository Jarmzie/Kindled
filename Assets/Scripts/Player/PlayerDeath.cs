using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int playerHealth = 3;
    [SerializeField] Transform spawnPoint;
   
    

    void TakeDamage (int damage)
    {
        playerHealth -= 1;
        if (playerHealth == 0)
        {
            gameObject.transform.position = spawnPoint.position;
            playerHealth = 3;

            GameObject thePlayer = GameObject.Find("Player (Legs)");
            PlayerAimWeapon playerAimWeapon = thePlayer.GetComponent<PlayerAimWeapon>();
            playerAimWeapon.currentOil = 200;
        }
    }
}

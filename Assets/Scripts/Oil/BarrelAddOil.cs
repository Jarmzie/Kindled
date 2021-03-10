using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAddOil : MonoBehaviour
{
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject thePlayer = GameObject.Find("Player (Legs)");
        PlayerAimWeapon playerAimWeapon = thePlayer.GetComponent<PlayerAimWeapon>();
        

        if (col.gameObject.CompareTag("Player"))
        {
            playerAimWeapon.currentOil += 100;
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("PlayerProjectile"))
        {
            
            Destroy(gameObject);
        }
    }
}

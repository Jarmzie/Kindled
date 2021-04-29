using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public int playerHealth = 3;
    public float timeAtHealthChange, regenRate = 10;
    private bool inHitStun = false;
    public GameObject bloodVignette, torso;
    private Image bvsr;
    private PlayerUpgradeController upgrades;

    private void Start()
    {
        bvsr = bloodVignette.GetComponent<Image>();
        upgrades = GetComponent<PlayerUpgradeController>();
        timeAtHealthChange = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        //This break with too many regen upgrades, shouldn't happen during normal gameplay tho
        if (Time.timeSinceLevelLoad - timeAtHealthChange > (regenRate - upgrades.healthRegenUpgrades) && playerHealth <3 && playerHealth > 0)
        {
            healDamage();
        }
    }

    IEnumerator TakeDamage (int damage)
    {
        FindObjectOfType<AudioManager>().Plays("PlayerHurt");
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
            yield return new WaitForSeconds(4);
            FindObjectOfType<AudioManager>().Plays("TownHubMusic");
            yield break;
            
        }
        timeAtHealthChange = Time.timeSinceLevelLoad;

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

    public void healDamage()
    {
        playerHealth++;
        timeAtHealthChange = Time.timeSinceLevelLoad;
        UpdateBlood();
    }

    private void UpdateBlood()
    {
        if (playerHealth == 2)
        {
            //FindObjectOfType<AudioManager>().Stop("Heartbeat");
            bvsr.color = new Vector4(1, 1, 1, 0.15f);
        }
        else if (playerHealth == 1)
        {
            //FindObjectOfType<AudioManager>().Plays("Heartbeat");
            bvsr.color = new Vector4(1, 1, 1, 0.33f);
        } else
        {
            //FindObjectOfType<AudioManager>().Stop("Heartbeat");
            bvsr.color = new Vector4(1, 1, 1, 0);
        }
    }

    public void PlayerDie()
    {
        FindObjectOfType<AudioManager>().Stop("CaveMusic");
        FindObjectOfType<AudioManager>().Stop("RuinMusic");
        FindObjectOfType<AudioManager>().Plays("DeathMusic");
        FindObjectOfType<AudioManager>().Plays("PlayerDeath");
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Destroy(torso);
        GetComponent<PlayerLightController>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAnimation>().enabled = false;
        GetComponent<Animator>().SetTrigger("Death");
        GameObject.FindGameObjectWithTag("LevelLogic").GetComponent<LevelLogic>().StartDeathCoroutine(gameObject);
    }

  
}

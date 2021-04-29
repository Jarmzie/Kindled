using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFrontBackButItNeedsToBeQuickBecauseThisIsDueInAnHour : MonoBehaviour
{
    [SerializeField]
    float posX = 0, posY = 0;
    SpriteRenderer sr;
    GameObject player;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player (Legs)");
    }

    public void FixedUpdate()
    {
        if (player.transform.position.y > transform.position.y + posY)
        {
            sr.sortingLayerName = "EnemyInFront";
        }
        else
        {
            sr.sortingLayerName = "EnemyInBack";
        }
    }
}

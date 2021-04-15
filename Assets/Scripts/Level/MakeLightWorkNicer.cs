using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLightWorkNicer : MonoBehaviour
{
    [SerializeField]
    float posX, posY;
    SpriteRenderer sr;
    GameObject player;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player (Legs)");
    }

    public void FixedUpdate()
    {
        if (player.transform.position.x > posX && player.transform.position.y > posY)
        {
            sr.sortingLayerName = "FrontOfPlayer";
        }
        else
        {
            sr.sortingLayerName = "Decor";
        }
    }
}

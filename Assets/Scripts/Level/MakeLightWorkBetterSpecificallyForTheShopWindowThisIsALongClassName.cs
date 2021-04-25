using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLightWorkBetterSpecificallyForTheShopWindowThisIsALongClassName : MonoBehaviour
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
        if (player.transform.position.x > posX && player.transform.position.y > posY)
        {
            sr.sortingLayerName = "LitFrontOfPlayer";
        }
        else
        {
            sr.sortingLayerName = "LitDecor";
        }
    }
}

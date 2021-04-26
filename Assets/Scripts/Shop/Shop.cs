using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    ShopList myShopList = new ShopList();
    [SerializeField]
    Image currLant, prevLant, nextLant;
    [SerializeField]
    Text lantName, lantDesc;
    int iterator = 0;
    [SerializeField]
    List<Sprite> lanternSpriteList = new List<Sprite>();

    private void Awake()
    {
        //Every inch of my body hates this but I don't have time to learn how to do it correctly
        myShopList.addNode(new ShopNode(
            lanternSpriteList[0],
            false,
            "Hood Lantern",
            "You're trusty old lantern. Shoots a basic fireball that does decent damage."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[1],
            false,
            "Lava Lantern",
            "A spare lantern owned by Bjartur. It takes extra oil but does more damage. It's also a bit slow."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[2],
            false,
            "Tiki Lantern",
            "A lantern from a far away land. Who knows how it got down in the dungeon. Shoots fast projectiles that can do some damage. Very slow."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[3],
            false,
            "Candle Lantern",
            "An intricately designed lamp and was found at the bottom of the dungeon. Shoots multiple small projectiles that don't do much damage."
        ));

        WouldYouLikeToBuyMyWares();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveIteratorAndUpdate(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveIteratorAndUpdate(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }

    private void MoveIteratorAndUpdate(bool right)
    {
        if (right)
        {
            if (iterator + 1 >= myShopList.Count())
            {
                iterator = 0;
            } else
            {
                iterator++;
            }
            WouldYouLikeToBuyMyWares();
        } else if (!right)
        {
            if (iterator == 0)
            {
                iterator = myShopList.Count() - 1;
            }
            else
            {
                iterator--;
            }
            WouldYouLikeToBuyMyWares();
        }
    }

    private void WouldYouLikeToBuyMyWares()
    {
        ShopNode temp = myShopList.getNode(iterator);
        currLant.sprite = temp.getSprite();
        prevLant.sprite = temp.prev.getSprite();
        nextLant.sprite = temp.next.getSprite();
        lantName.text = temp.getName();
        lantDesc.text = temp.getDesc();
    }
}

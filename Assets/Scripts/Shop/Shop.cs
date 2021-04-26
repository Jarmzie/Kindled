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
            "Lantern 1",
            "This is the description for lantern 1"
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[1],
            false,
            "Lantern 2",
            "This is the description for lantern 2"
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[2],
            false,
            "Lantern 3",
            "This is the description for lantern 3"
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[3],
            false,
            "Lantern 4",
            "This is the description for lantern 4"
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

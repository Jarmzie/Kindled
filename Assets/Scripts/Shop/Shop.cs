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
    List<Sprite> lanternSpriteList = new List<Sprite>(), inGameSpriteList = new List<Sprite>();
    [SerializeField]
    List<GameObject> projectileList = new List<GameObject>();
    [SerializeField]
    Sprite lockedSprite;
    HubStateManager hub;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(false);
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        //Every inch of my body hates this but I don't have time to learn how to do it correctly
        myShopList.addNode(new ShopNode(
            lanternSpriteList[0],
            inGameSpriteList[0],
            projectileList[0],
            0.3f,
            false,
            "Hood Lantern",
            "You're trusty old lantern. Shoots a basic fireball that does decent damage."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[1],
            inGameSpriteList[1],
            projectileList[1],
            0.45f,
            false,
            "Lava Lantern",
            "A spare lantern owned by Bjartur. It takes extra oil but does more damage. It's also a bit slow."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[2],
            inGameSpriteList[2],
            projectileList[2],
            0.55f,
            !hub.ThirdLanternAquired,
            "Lantern Post",
            "A lantern from a far away land, you can't even hold it upright. Who knows how it got down in the dungeon. Shoots fast projectiles that can do some damage. Very slow."
        ));
        myShopList.addNode(new ShopNode(
            lanternSpriteList[3],
            inGameSpriteList[3],
            projectileList[3],
            0.2f,
            !hub.FinalLanternAquired,
            "Draught Lantern",
            "An intricately designed lamp that was found at the bottom of the dungeon. Shoots multiple small projectiles that don't do much damage."
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
            ShopNode temp = myShopList.getNode(iterator);
            if (!temp.getLocked())
            {
                hub.currLantern = temp;
                GameObject.FindGameObjectWithTag("Lantern").GetComponent<Lantern>().ShipOfTheseus(temp.getName(), temp.getInGameSprite(), temp.getProjectile(), temp.getShotSpeed());
                GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(true);
                Destroy(gameObject);
            }
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
        if (!temp.getLocked())
        {
            currLant.sprite = temp.getSprite();
            lantName.text = temp.getName();
            lantDesc.text = temp.getDesc();
        } else
        {
            currLant.sprite = lockedSprite;
            lantName.text = "Unknown";
            lantDesc.text = "Continue into the dungeon to find this lantern.";
        }
        if (!temp.prev.getLocked())
        {
            prevLant.sprite = temp.prev.getSprite();
        }
        else
        {
            prevLant.sprite = lockedSprite;
        }
        if (!temp.next.getLocked())
        {
            nextLant.sprite = temp.next.getSprite();
        }
        else
        {
            nextLant.sprite = lockedSprite;
        }
    }
}

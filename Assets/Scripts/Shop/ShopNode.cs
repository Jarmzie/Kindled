using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNode
{
    Sprite mySprite, inGameSprite;
    GameObject myProjectile;
    float shotSpeed;
    bool locked;
    string myName = "", myDesc = "";
    public ShopNode prev, next;

    public ShopNode(Sprite mySprite_, Sprite inGameSprite_, GameObject myProjectile_, float shotSpeed_, bool locked_, string name_, string desc_)
    {
        mySprite = mySprite_;
        inGameSprite = inGameSprite_;
        myProjectile = myProjectile_;
        shotSpeed = shotSpeed_;
        locked = locked_;
        myName = name_;
        myDesc = desc_;
    }

    public Sprite getSprite()
    {
        return mySprite;
    }

    public string getName()
    {
        return myName;
    }

    public string getDesc()
    {
        return myDesc;
    }

    public bool getLocked()
    {
        return locked;
    }

    public Sprite getInGameSprite()
    {
        return inGameSprite;
    }

    public float getShotSpeed()
    {
        return shotSpeed;
    }

    public GameObject getProjectile()
    {
        return myProjectile;
    }
}

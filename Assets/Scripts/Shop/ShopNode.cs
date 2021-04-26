using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNode
{
    [SerializeField]
    Sprite mySprite;
    [SerializeField]
    bool locked;
    string myName = "", myDesc = "";
    public ShopNode prev, next;

    public ShopNode(Sprite mySprite_, bool locked_, string name_, string desc_)
    {
        mySprite = mySprite_;
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
}

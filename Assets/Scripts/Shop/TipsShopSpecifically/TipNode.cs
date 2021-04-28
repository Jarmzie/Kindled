using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipNode
{
    Sprite mySprite;
    string myName = "", myDesc = "";
    string[] tipDialogue;
    public TipNode prev, next;

    public TipNode(string[] tipDialogue_, Sprite mySprite_, string name_, string desc_)
    {
        tipDialogue = tipDialogue_;
        mySprite = mySprite_;
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

    public string[] getDialogue()
    {
        return tipDialogue;
    }
}

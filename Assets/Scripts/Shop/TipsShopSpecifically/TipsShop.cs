using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsShop : MonoBehaviour
{
    TipsList myTipList = new TipsList();

    [SerializeField]
    Image currTip, prevTip, nextTip;
    [SerializeField]
    Text tipName, tipDesc;
    int iterator = 0;
    [SerializeField]
    List<Sprite> tipSpriteList = new List<Sprite>();
    HubStateManager hub;

    [SerializeField]
    GameObject dialogueBox;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(false);
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        //Every inch of my body hates this but I don't have time to learn how to do it correctly, and now I have to do it twice
        myTipList.addNode(new TipNode( new string[] {
            "Hallo! How about we talk about controls?",
                    "I would hope you know how to walk around, but just in case I guess I could give you some help.",
                    "Imagine your feet are a keyboard, and each direction you want to move is one of the WASD keys. Hopefully that's a good enough.",
                    "To shoot your lantern, try imagining your hand is a computer mouse. Try aiming the cursor in the direction you want to shoot.",
                    "After you've done that, imagine clicking the left mouse button.",
                    "Oh, I almost forgot about pausing.",
                    "This analogy might be a strectch but bear with me.",
                    "Imagine you're a player, sitting at a computer. Then press the ESC button on the keyboard. That should allow you to pause the game.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[0], "Controls", "Hear some tips about the controls of the game."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about why you're here?",
                    "Obviously you know that you were sent here by your boss. But you already knew that.",
                    "We have a problem. As you can see around, the oil lake that usually surrounds us on all sides has sorta gone missing.",
                    "I have a fairly large hunch that the solution to this problem of the missing lake has something to do with the dungeon.",
                    "So that's why I requested someone expendable to explore the dungeon for us!",
                    "Oops. I shouldn't have said that out loud.",
                    "Just ignore I said anything at all and get back down in that dungeon!",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[1], "Your Mission", "Hear some insight into why you're entering the dungeon."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about the dungeon?",
                    "The dungeon is a large interconnected series of seemingly random rooms that don't make any logical sense.",
                    "Also, it's filled with monsters!",
                    "In all seriousness, it's a pretty dangerous place. Each floor has a wave of monsters that you must defeat before traveling lower.",
                    "Luckily, I've heard rumors of safe areas with loot every couple floors. But you can ask me about those seperately.",
                    "Another thing to note is that the amount of monsters increases every floor. So be careful as you go deeper.",
                    "One last thing. Halfway through the dungeon the floors seem to change color. So be aware of that.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[2], "The Dungeon", "Hear some tips about how the dungeon works."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about your oil and health?",
                    "That meter up in the top right corner of your vision is called your Oil Bar. It tells you how much oil you have left.",
                    "Oil is used for your light and your ammo. Which means, at all times it will be depleting. It also means attacking enemies depletes it as well.",
                    "Luckily, the monsters down there are made of pure oil. So anytime you kill one, you get oil back.",
                    "You also get some oil back for finishing an entire floor.",
                    "Be careful you don't run out. If you run out, you're done for.",
                    "This is mostly because that model of suit you're using self-destructs when it doesn't have anymore oil to use! Gotta love defective products!",
                    "That's not the only way you can bite the dust. If you get hit too many times by enemies, your suit will malfunction and self-destruct as well.",
                    "Luckily, your suit is self-repairing. So if you get hit, you just have to not get hit for a certain amount of time and you'll heal up.",
                    "I would give you three hits before the suit decides it's had enough. So make sure if you've gotten hit twice to retreat for a while.",
                    "Also, one last thing. If you happen to spill some oil on yourself, make sure you don't touch water.",
                    "We really don't want another \"Heaven Stairway\" incident.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[3], "Oil and Health", "Hear some tips about oil and your health."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about the Oil Rig?",
                    "She's a beaut, ain't she? I've been stationed here for as long as I can remember.",
                    "It's a bit lonely, especially since Bjartur ain't the most talkitive.",
                    "We do frequently get visitors! Just usually not many at the same time... And they usually don't stay for long...",
                    "Most of the time, once someone new disappears, a new one always follows suit soon after.",
                    "But now we have you! And you haven't \"disappeared\" yet! Right?",
                    "That's besides the point. You can use the Oil Rig as your one stop shop for my tips and Bjartur's... uh... shop.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[4], "The Oil Rig", "Hear some insight into the Oil Rig (the hub)."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about Bjartur's shop?",
                    "I assume you've bet Bjartur. I don't think he likes me very much.",
                    "To be honest, I don't think he likes many people very much. But I digress.",
                    "The shop can be used to switch out your lanterns. It seems Bjartur is even gonna let you use one of his lanterns.",
                    "If you find any more lanterns, it's possible that Bjartur might even let you keep more there. Just don't overstay your welcome.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[5], "Bjartur's Shop", "Hear some insight into Bjartur and his shop."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about your lanterns?",
                    "The shop has a selection of lanterns for you to pick from. They also still has a few open spots for more if you happen to find any.",
                    "Each lantern is unique. They can vary with how much oil they take to shoot, how much damage they do, and how long it takes to shoot them.",
                    "These aren't the only differences. I've even heard of a lantern that can shoot mutliple projectiles at once! Who knows if it actually exists.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[6], "Lanterns", "Hear some tips about different lanterns."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about Banterns?",
                    "Oh, you might now know what I'm talking about. It's those flying lantern things in the dungeon.",
                    "In my studies I've picked up a few things about them.",
                    "First of all, you don't want to get too close to them. If you're too close, they'll swoop at you to try and hurt you.",
                    "If you're out of their range, they'll either shoot at you or reposition themselves.",
                    "They don't take too much damage to off them, but you could easily get overwhelmed by a bunch of them.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[7], "Banterns", "Hear some tips about how to fight Banterns."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about Disk Devils?",
                    "Oh, you might not know what I'm talking about. It's those floating circle things that bounce around in the dungeon.",
                    "They're fairly non-hostile, so they'll never directly go after you.",
                    "Instead, they like to go with the flow, and if you happen to be within their flow, they'll happily fly straight into you.",
                    "It's even worse that they have no natural light on them, so they can come flying straight out of the darkness!",
                    "One time while I was down there, one knocked my head right off my body! And out of nowhere!",
                    "That's why I've decided to stay up here instead. It's much quieter and less decapitation-y.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[8], "Disk Devils", "Hear some tips about how to fight Disk Devils."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about Drillburns?",
                    "Oh, you might not know what I'm talking about. It's those pink drill like machines down in the dungeon.",
                    "These little guys have a bit of a sad life. They can't see very well since their eyes are on the sides of their head.",
                    "They basically roam aimlessly, only turning around when they bump into something.",
                    "They'll also go into Ultra Intsinct mode and charge at anything that spooks them, so be carefull walking past their sides.",
                    "At least they'll tire themselves out quickly after the charge. It gives you the opportunity to get a few attacks in!",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[9], "Drillburns", "Hear some tips about how to fight Drillburns."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about Litwicks?",
                    "Oh, you might not know what I'm talking about. It's those living candle stick punks that show up in the dungeon.",
                    "As you probably have noticed, they have no appendages. This makes it so they pretty much just sit in place.",
                    "That doesn't make them any less of a threat. They throw bits of themselves at you from across the entire room!",
                    "It doesn't stop there! They'll also sometimes throw hot wax onto the floor next to themselves.",
                    "This wax doesn't light up so it's probably a good idea to keep a watch out while approaching Litwicks.",
                    "Seems a bit asinine to throw bits of yourself to try and protect yourself, but who am I to judge?",
                    "Also, please don't tell anyone about the name, I might have stolen it from a video game I like.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[10], "Litwicks", "Hear some tips about how to fight Litwicks."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about upgrade rooms?",
                    "I've heard rumors of rooms with loot down in the dungeon.",
                    "Apparently, they only show up every once in a while, but don't quote me on that.",
                    "If I were to take an educated guess, you have a good chance of seeing about three of them on your way to the bottom of the dungeon.",
                    "But this is all heresay, I actually have no idea what I'm talking about.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[11], "Upgrade Rooms", "Hear some insight into upgrade rooms that are found in the dungeon."));
        myTipList.addNode(new TipNode(new string[] {
            "Hallo! How about we talk about the bottom of the dungeon?",
                    "I actually don't know much about the bottom of the dungeon. I just know at some point the walls change color. But I haven't made it much past there.",
                    "I've researched the dungeon a lot, but I'm not a fighter. It took a lot of enginuity to get as far as I have!",
                    "The thing I do know is that I'm like 90% sure the reason that the oil lake has dried up is tied to the dungeon in some way!",
                    "Like, there's a pretty good 75% chance that once you get down there, all of our problems will be gone",
                    "I'm fairly confident there's a 50/50 chance that we're sending you down there for a good reason!",
                    "Yep, there's about a 25% chance that I'm 100% correct.",
                    "...",
                    "Hehe...",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
        }, tipSpriteList[12], "The Bottom of the Dungeon", "Hear some insight about what's at the bottom of the dungeon."));
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
            TipNode temp = myTipList.getNode(iterator);
            GameObject dialogue = Instantiate(dialogueBox);
            dialogue.GetComponent<Dialogue>().RunDialogue("Alto: ", temp.getDialogue());
            Destroy(gameObject);
        }
    }

    private void MoveIteratorAndUpdate(bool right)
    {
        if (right)
        {
            if (iterator + 1 >= myTipList.Count())
            {
                iterator = 0;
            }
            else
            {
                iterator++;
            }
            WouldYouLikeToBuyMyWares();
        }
        else if (!right)
        {
            if (iterator == 0)
            {
                iterator = myTipList.Count() - 1;
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
        TipNode temp = myTipList.getNode(iterator);
        currTip.sprite = temp.getSprite();
        tipName.text = temp.getName() + " (E)";
        tipDesc.text = temp.getDesc();
        prevTip.sprite = temp.prev.getSprite();
        nextTip.sprite = temp.next.getSprite();
    }
}

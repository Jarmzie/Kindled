using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTipsWindow : Interactable
{
    private HubStateManager hub;
    private const string SQUID_NAME = "Alto: ";

    [SerializeField]
    private GameObject dialoguePrefab, tipsShop;

    public void Awake()
    {
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        if (hub.myTutState == HubStateManager.TutorialState.FirstLoad)
        {
            InteractMessage = "Talk to Squid - Press 'E'";
        } else
        {
            InteractMessage = "Talk to Alto - Press 'E'";
        }
    }

    public override IEnumerator OnInteract()
    {
        if (hub == null)
        {
            print("No HubManagerFound");
            yield break;
        }
        GameObject tempDialogue = Instantiate(dialoguePrefab, Vector3.zero, Quaternion.identity);
        switch (hub.myTutState)
        {
            case HubStateManager.TutorialState.FirstLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue("Squid: ", new string[] {
                    "Oh, hallo! You must be new here! My name is Alto, nice to meet you!",
                    "My job here to is act as a researcher. I'm also in charge of telling people like you how to do their jobs correctly!",
                    "It seems you already know how to move your legs since you made it over here, which means you're ahead of the curve!",
                    "Anyway, you might have seen the entrance to the dungeon over near the front of the platform. That's where you'll be doing most of your work.",
                    "Your primary directive in the dungeon is to get to the bottom of it, though there are a couple things that might get in your way.",
                    "The dungeon consists of series of randomized dark rooms filled with monsters.",
                    "To see down there and to attack these monsters, you must use your lantern. Click in the direction you want to shoot to attack with your lantern.",
                    "Luckily, it looks like you've already come equipped with your own lantern and some oil. Good job on being prepared!",
                    "That oil isn't going to last forever. Shooting and being in the dark will both take oil.",
                    "If you're out of oil, you're a goner. So just don't let that happen! Okay?",
                    "And one last thing. I don't think I should have to tell you this but don't let the monsters hit you. That's a surefire way to kick the bucket.",
                    "But that's it. If you need anything re-explained or more in-depth info, just come talk with me again! I've got much to talk about!",
                    "Anyway, good luck and have fun in the dungeon!"
                    //"That oil isn't going to last you forever though, so be careful about how long you take in the dark. Oil won't burn when you're not in the dark.",
                    //"If you're out of oil, you're a goner. So just don't let that happen! Okay?",
                    //"That lantern you have is also your primary weapon, but attacking with it will ALSO use oil, so be careful missing too many shots.",
                    //"So let's talk about the dungeon. As you might have picked up on, there's a lotta monsters down there.",
                    //"Most levels of the dungeon will have these monsters. You'll have to defeat all of them if you want to go to the lower levels.",
                    //"Speaking of the levels, the rooms in the dungeon can shift around and feel random.",
                    //"Let it be known that even if it feels like you've been to a room before, you're still making progress.",
                    //"You might be able to see your progress if you come to a room with no monsters, maybe you'll find something useful down there.",
                    //"Who knows though, nobody has ever gotten that far. Maybe you will!                                                  (but i doubt it)",
                    //"And one last thing. I don't think I should have to tell you this but don't let the monsters touch you. That's a surefire way to kick the bucket.",
                    //"But that's pretty much it. I think you're ready to head into the dungeon. Good luck, have fun!",
                    //"Oh, and come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.GoodToGo;
                break;
            case HubStateManager.TutorialState.GoodToGo:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] { 
                    "Hallo! Go ahead and ask me anything!",
                }, gameObject, "OpenTips");
                break;
            default:
                tempDialogue.GetComponent<Dialogue>().RunDialogue("", new string[] { });
                break;
        }
        yield return null;
    }

    public void DialogueEnd(string CallbackID)
    {
        if (CallbackID == "OpenTips")
        {
            Instantiate(tipsShop);
        }
    }















    /*
    case HubStateManager.TutorialState.Controls:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hallo! How about we talk about controls?",
                    "I would hope you know how to walk around, but just in case I guess I could give you some help.",
                    "Imagine your feet are a keyboard, and each direction you want to move is one of the WASD keys. Hopefully that's a good enough.",
                    "To shoot your lantern, try imagining your hand is a computer mouse. Try aiming the cursor in the direction you want to shoot.",
                    "After you've done that, imagine clicking the left mouse button.",
                    "Oh, I almost forgot about pausing.",
                    "This analogy might be a strectch but bear with me.",
                    "Imagine you're a player, sitting at a computer. Then press the ESC button on the keyboard. That should allow you to pause the game.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Why;
                break;
            case HubStateManager.TutorialState.Why:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hallo! How about we talk about why you're here?",
                    "Obviously you know that you were sent here by your boss. But you already knew that.",
                    "We have a problem. As you can see around, the oil lake that usually surrounds us on all sides has sorta gone missing.",
                    "I have a fairly large hunch that the solution to this problem of the missing lake has something to do with the dungeon.",
                    "So that's why I requested someone expendable to explore the dungeon for us!",
                    "Oops. I shouldn't have said that out loud.",
                    "Just ignore I said anything at all and get back down in that dungeon!",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.TheDungeon;
                break;
            case HubStateManager.TutorialState.TheDungeon:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hallo! How about we talk about the dungeon?",
                    "The dungeon is a large interconnected series of seemingly random rooms that don't make any logical sense.",
                    "Also, it's filled with monsters!",
                    "In all seriousness, it's a pretty dangerous place. Each floor has a wave of monsters that you must defeat before traveling lower.",
                    "Luckily, I've heard rumors of safe areas with loot every couple floors. But you can ask me about those seperately.",
                    "Another thing to note is that the amount of monsters increases every floor. So be careful as you go deeper.",
                    "One last thing. Halfway through the dungeon the floors seem to change color. So be aware of that.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Oil;
                break;
            case HubStateManager.TutorialState.Oil:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about your oil and health?",
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
                });
                hub.myTutState = HubStateManager.TutorialState.TheHub;
                break;
            case HubStateManager.TutorialState.TheHub:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hallo! How about we talk about the Oil Rig?",
                    "She's a beaut, ain't she? I've been stationed here for as long as I can remember.",
                    "It's a bit lonely, especially since Bjartur ain't the most talkitive.",
                    "We do frequently get visitors! Just usually not many at the same time... And they usually don't stay for long...",
                    "Most of the time, once someone new disappears, a new one always follows suit soon after.",
                    "But now we have you! And you haven't \"disappeared\" yet! Right?",
                    "That's besides the point. You can use the Oil Rig as your one stop shop for my tips and Bjartur's... uh... shop.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.TheShop;
                break;
            case HubStateManager.TutorialState.TheShop:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about Bjartur's shop?",
                    "I assume you've bet Bjartur. I don't think he likes me very much.",
                    "To be honest, I don't think he likes many people very much. But I digress.",
                    "The shop can be used to switch out your lanterns. It seems Bjartur is even gonna let you use one of his lanterns.",
                    "If you find any more lanterns, it's possible that Bjartur might even let you keep more there. Just don't overstay your welcome.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Lanterns;
                break;
            case HubStateManager.TutorialState.Lanterns:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about your lanterns?",
                    "The shop has a selection of lanterns for you to pick from. They also still has a few open spots for more if you happen to find any.",
                    "Each lantern is unique. They can vary with how much oil they take to shoot, how much damage they do, and how long it takes to shoot them.",
                    "These aren't the only differences. I've even heard of a lantern that can shoot mutliple projectiles at once! Who knows if it actually exists.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Banterns;
                break;
            case HubStateManager.TutorialState.Banterns:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about Baterns?",
                    "Oh, you might now know what I'm talking about. It's those flying lantern things in the dungeon.",
                    "In my studies I've picked up a few things about them.",
                    "First of all, you don't want to get too close to them. If you're too close, they'll swoop at you to try and hurt you.",
                    "If you're out of their range, they'll either shoot at you or reposition themselves.",
                    "They don't take too much damage to off them, but you could easily get overwhelmed by a bunch of them.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.DiskDevils;
                break;
            case HubStateManager.TutorialState.DiskDevils:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about Disk Devils?",
                    "Oh, you might not know what I'm talking about. It's those floating circle things that bounce around in the dungeon.",
                    "They're fairly non-hostile, so they'll never directly go after you.",
                    "Instead, they like to go with the flow, and if you happen to be within their flow, they'll happily fly straight into you.",
                    "It's even worse that they have no natural light on them, so they can come flying straight out of the darkness!",
                    "One time while I was down there, one knocked my head right off my body! And out of nowhere!",
                    "That's why I've decided to stay up here instead. It's much quieter and less decapitation-y.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Drillburns;
                break;
            case HubStateManager.TutorialState.Drillburns:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about Drillburns?",
                    "Oh, you might not know what I'm talking about. It's those pink drill like machines down in the dungeon.",
                    "These little guys have a bit of a sad life. They can't see very well since their eyes are on the sides of their head.",
                    "They basically roam aimlessly, only turning around when they bump into something.",
                    "They'll also go into Ultra Intsinct mode and charge at anything that spooks them, so be carefull walking past their sides.",
                    "At least they'll tire themselves out quickly after the charge. It gives you the opportunity to get a few attacks in!",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Litwicks;
                break;
            case HubStateManager.TutorialState.Litwicks:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about Litwicks?",
                    "Oh, you might not know what I'm talking about. It's those living candle stick punks that show up in the dungeon.",
                    "As you probably have noticed, they have no appendages. This makes it so they pretty much just sit in place.",
                    "That doesn't make them any less of a threat. They throw bits of themselves at you from across the entire room!",
                    "It doesn't stop there! They'll also sometimes throw hot wax onto the floor next to themselves.",
                    "This wax doesn't light up so it's probably a good idea to keep a watch out while approaching Litwicks.",
                    "Seems a bit asinine to throw bits of yourself to try and protect yourself, but who am I to judge?",
                    "Also, please don't tell anyone about the name, I might have stolen it from a video game I like.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.UpgradeRooms;
                break;
            case HubStateManager.TutorialState.UpgradeRooms:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about upgrade rooms?",
                    "I've heard rumors of rooms with loot down in the dungeon.",
                    "Apparently, they only show up every once in a while, but don't quote me on that.",
                    "If I were to take an educated guess, you have a good chance of seeing about three of them on your way to the bottom of the dungeon.",
                    "But this is all heresay, I actually have no idea what I'm talking about.",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.BottomOfDungeon;
                break;
            case HubStateManager.TutorialState.BottomOfDungeon:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(SQUID_NAME, new string[] {
                    "Hey, how about we talk about the bottom of the dungeon?",
                    "I actually don't know much about the bottom of the dungeon. I just know at some point the walls change color. But I haven't made it much past there.",
                    "I've researched the dungeon a lot, but I'm not a fighter. It took a lot of enginuity to get as far as I have!",
                    "The thing I do know is that I'm like 90% sure the reason that the oil lake has dried up is tied to the dungeon in some way!",
                    "Like, there's a pretty good 75% chance that once you get down there, all of our problems will be gone",
                    "I'm fairly confident there's a 50/50 chance that we're sending you down there for a good reason!",
                    "Yep, there's about a 25% chance that I'm 100% correct.",
                    "...",
                    "Hehe...",
                    "Anyway, I hope that helps! Come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.Controls;
                break;*/



}

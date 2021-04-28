using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTipsWindow : Interactable
{
    private HubStateManager hub;
    private const string SQUID_NAME = "Alto: ";

    [SerializeField]
    private GameObject dialoguePrefab;

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
                    "Oh, hallo!",
                    "You must be new here! My name is Alto, nice to meet you!",
                    "My job here to is tell people like you how to do your jobs correctly!",
                    "It seems you already know how to move your legs since you made it over here, which means you're ahead of the curve!",
                    "Could it be that you already know how to survive in the dungeon?",
                    "Anyway, you might have seen the entrance to the dungeon over near the front of the platform. That's where you'll be doing most of your work.",
                    "It's very dark down there, darker than up here, so you won't be able to see much.",
                    "Luckily, it looks like you've already come equipped with your own lantern and oil. Good job on being prepared!",
                    "That oil isn't going to last you forever though, so be careful about how long you take in the dark. Oil won't burn when you're not in the dark.",
                    "If you're out of oil, you're a goner. So just don't let that happen! Okay?",
                    "That lantern you have is also your primary weapon, but attacking with it will ALSO use oil, so be careful missing too many shots.",
                    "So let's talk about the dungeon. As you might have picked up on, there's a lotta monsters down there.",
                    "Most levels of the dungeon will have these monsters. You'll have to defeat all of them if you want to go to the lower levels.",
                    "Speaking of the levels, the rooms in the dungeon can shift around and feel random.",
                    "Let it be known that even if it feels like you've been to a room before, you're still making progress.",
                    "You might be able to see your progress if you come to a room with no monsters, maybe you'll find something useful down there.",
                    "Who knows though, nobody has ever gotten that far. Maybe you will!                                                  (but i doubt it)",
                    "And one last thing. I don't think I should have to tell you this but don't let the monsters touch you. That's a surefire way to kick the bucket.",
                    "But that's pretty much it. I think you're ready to head into the dungeon. Good luck, have fun!",
                    "Oh, and come back if you ever need more help! I've got plenty of things to talk about!"
                });
                hub.myTutState = HubStateManager.TutorialState.GoodToGo;
                break;
            default:
                tempDialogue.GetComponent<Dialogue>().RunDialogue("", new string[] { });
                break;
        }
        yield return null;
    }
}

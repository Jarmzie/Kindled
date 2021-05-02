using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractShopWindow : Interactable
{
    private HubStateManager hub;
    private const string MOTH_NAME = "Bjartur: "; 

    [SerializeField]
    private GameObject dialoguePrefab, shopPrefab;

    public void Awake()
    {
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        if (hub.myState == HubStateManager.ShopState.FirstLoad)
        {
            InteractMessage = "Talk to Shop Keeper - Press 'E'";
        } else
        {
            InteractMessage = "Talk to Bjartur - Press 'E'";
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
        switch (hub.myState)
        {
            case HubStateManager.ShopState.FirstLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue("Shop Keeper: ", new string[] {
                    "Hmmmm... They sent a new one, huh?",
                    "I have nothing to say to you right now.",
                    "You're gonna want to talk to Alto. He's the one sitting at that silly little \"tips\" shop. He'll give you more info about the dungeon.",
                    "Maybe come back after you've tried out the dungeon. I might change my mind about talking to you."
                });
                break;
            case HubStateManager.ShopState.SecondLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Wow! You did awful!",
                    "You're really going to need my help, huh?",
                    "Well fine. Maybe you can replace that dinky old lantern with one from my collection!",
                    "Here, have a look around."
                }, gameObject, "shop");
                hub.myState = HubStateManager.ShopState.Default;
                break;
            case HubStateManager.ShopState.Default:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Welcome back. Made any progress in the dungeon yet?"
                }, gameObject, "shop");
                break;
            case HubStateManager.ShopState.ThirdLantern:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Welcome back. Made any progress in the dungeon yet?",
                    "Oh... You have, you say?",
                    "A lantern, huh? Well it looks better than any we have here right now. So I guess that's nice.",
                    "I'll keep it in stock for you to take it whenever you want."
                }, gameObject, "shop");
                hub.ThirdLanternAquired = true;
                hub.myState = HubStateManager.ShopState.Default;
                break;
            case HubStateManager.ShopState.FinishedGameInit:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Welcome back. Made any progress in the dungeon yet?",
                    "Wait! You actually made it to the bottom?! You must be lying to me!",
                    "So you turned on a generator? Huh.",
                    "Wait! That might've been why my TV suddenly turned on!",
                    "That thing's been out of commision for the longest time. But I guess that means the generator had nothing to do with the lake.",
                    "It looks like you got a pretty interesting looking lantern though.",
                    "I guess I can keep that here for you. Looks intense.",
                    "Anyway, I guess we have to start thinking of another thing to blame for the oil lake drying up.",
                    "In the meantime, I'll still be around to let you switch out your lanterns."
                }, gameObject, "shop");
                hub.FinalLanternAquired = true;
                hub.myState = HubStateManager.ShopState.FinishedGame;
                break;
            case HubStateManager.ShopState.FinishedGame:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "I still can't believe that you actually made it to the bottom. Makes me want to try my luck down there."
                }, gameObject, "shop");
                break;
            case HubStateManager.ShopState.SkippedSecondLoad2ThirdLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Wow. You got pretty far down there. And without my help too.",
                    "I was going to tell you you could use my lanterns, but apparently you didn't need it as much as I thought.",
                    "Oh, you've found a lantern? Well I guess my services can come in handy.",
                    "I'll keep it in stock for you to take it whenever you want.",
                    "I've also got another lantern lying around if you'd like to take that for a spin."
                }, gameObject, "shop");
                hub.ThirdLanternAquired = true;
                hub.myState = HubStateManager.ShopState.Default;
                break;
            case HubStateManager.ShopState.SkippedSecondLoad2FinalLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Holy $#*@! You just did the whole dang thing in one sweep!",
                    "I guess I really misjudged you, you didn't even need my help!",
                    "I see you have multiple new lanterns. Well I'm gonna let you have full use of my shop!",
                    "Just keep all your lanterns here and I'll let you come by and get them whenever you want. I'll even through in my own personal lantern.",
                    "But wait... The oil lake hasn't returned. Does that mean that the dungeon didn't have the solution?",
                    "You turned on the generator? Oh! That must've been why my TV suddenly started working.",
                    "That thing's been out of commision for the longest time. But I guess that means the generator had nothing to do with the lake.",
                    "Dang. Welp, I guess we'll have to find another thing to blame for our problems.",
                    "In the meantime, I'll still be around to let you switch out your lanterns.",
                    "Also thanks for sequence breaking the game. Because of you it makes the time put into making these special dialogue trees worth it."
                }, gameObject, "shop");
                hub.ThirdLanternAquired = true;
                hub.FinalLanternAquired = true;
                hub.myState = HubStateManager.ShopState.FinishedGame;
                break;
            case HubStateManager.ShopState.SkippedThirdLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Welcome back. Made any progress in the dungeon yet?",
                    "Wait! You actually made it to the bottom?! You must be lying to me!",
                    "I see you have multiple new lanterns. Well I guess that must prove that you've at least made some progress.",
                    "I'll take those lanterns off your hands. You can come by and take them to use in the dungeon any time.",
                    "But since you've been to the bottom now, I guess that means the dungeon didn't hold the reason behind the dried up oil lake.",
                    "You turned on the generator? Oh! That must've been why my TV suddenly started working.",
                    "That thing's been out of commision for the longest time. But I guess that means the generator had nothing to do with the lake.",
                    "Anyway, I guess we have to start thinking of another thing to blame for the oil lake drying up.",
                    "In the meantime, I'll still be around to let you switch out your lanterns."
                }, gameObject, "shop");
                hub.ThirdLanternAquired = true;
                hub.FinalLanternAquired = true;
                hub.myState = HubStateManager.ShopState.FinishedGame;
                break;
            default:
                tempDialogue.GetComponent<Dialogue>().RunDialogue("", new string[] { });
                break;
        }
        yield return null;
    }

    private void DialogueEnd(string callbackID)
    {
        if (callbackID == "shop")
        {
            Instantiate(shopPrefab);
        }
    }
}

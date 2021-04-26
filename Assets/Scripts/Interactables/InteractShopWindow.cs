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
        InteractMessage = "Talk to Shop Keeper - Press 'E'";
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
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Hmmmm... They sent a new one, huh?",
                    "I have nothing to say to you right now.",
                    "You're gonna want to talk to Alfie. He's the one sitting at that stupid \"tips\" table. He'll give you more info about the dungeon.",
                    "Maybe after I see how you fare in the dungeon I'll change my mind about talking to you."
                });
                break;
            case HubStateManager.ShopState.SecondLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Wow! That was awful!",
                    "You're really going to need my help, huh?",
                    "Well fine. Maybe you can replace that dinky old lantern with one from my collection!",
                    "Here, have a look around."
                }, gameObject, "shop");
                hub.myState = HubStateManager.ShopState.Default;
                break;
            case HubStateManager.ShopState.Default:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Weclome back. Made any progress in the dungeon yet?"
                }, gameObject, "shop");
                break;
            case HubStateManager.ShopState.ThirdLantern:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Weclome back. Made any progress in the dungeon yet?",
                    "Oh... You have, you say?",
                    "A lantern, huh? Well it looks better than any we have here right now. So I guess that's nice.",
                    "I'll keep it in stock for you to take it whenever you want it."
                }, gameObject, "shop");
                break;
            case HubStateManager.ShopState.FinishedGameInit:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "Welcome back. Made any progress in the dungeon yet?",
                    "Wait! You actually made it to the bottom?! You must be lying to me!",
                    "So there wasn't actually anything down there? Huh. It looks like you got a pretty interesting looking lantern though.",
                    "I guess I can keep that here for you. Looks intense.",
                    "Anyway, I guess we have to start thinking of another thing to blame for the oil lake drying up.",
                    "In the meantime, I'll still be around to let you switch out your lanterns."
                }, gameObject, "shop");
                break;
            case HubStateManager.ShopState.FinishedGame:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(MOTH_NAME, new string[] {
                    "I still can't believe that you actually made it to the bottom. Makes me want to try my luck down there."
                }, gameObject, "shop");
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

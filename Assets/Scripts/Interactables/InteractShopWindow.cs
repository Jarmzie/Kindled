using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractShopWindow : Interactable
{
    private HubStateManager hub;

    [SerializeField]
    private GameObject dialoguePrefab;

    public void Awake()
    {
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        InteractMessage = "Talk to Shop Keeper - Press 'E'";
    }

    public override IEnumerator OnInteract()
    {
        GameObject tempDialogue = Instantiate(dialoguePrefab, Vector3.zero, Quaternion.identity);
        switch (hub.myState)
        {
            case HubStateManager.ShopState.FirstLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(new string[] {
                    "Hmmmm... They sent a new one huh?",
                    "I have nothing to say to you right now.",
                    "Maybe after I see how you fare in the dungeon I'll change my mind."
                });
                break;
            case HubStateManager.ShopState.SecondLoad:
                tempDialogue.GetComponent<Dialogue>().RunDialogue(new string[] {
                    "Wow! That was awful!",
                    "You're really going to need my help, hun?",
                    "Well fine. Maybe you can replace that dinky old lantern with one from my collection!",
                    "Here, have a look around."
                });
                break;
            case HubStateManager.ShopState.FinishedGame:
                
                break;
        }
        yield return null;
    }
}

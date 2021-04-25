using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractShopWindow : Interactable
{
    public void Awake()
    {
        HubStateManager hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        switch (hub.myState)
        {
            case HubStateManager.ShopState.FirstLoad:
                InteractMessage = "Come back after you've proven yourself in the dungeon!";
                break;
            case HubStateManager.ShopState.SecondLoad:
                InteractMessage = "You must need my wares! - Press 'E'";
                break;
            case HubStateManager.ShopState.FinishedGame:
                InteractMessage = "You seem to have found a new lantern, how about you try it out? - Press 'E'";
                break;
        }
    }
}

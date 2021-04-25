using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStateManager : MonoBehaviour
{
    public ShopState myState = ShopState.FirstLoad;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        /*Shop = tempShop.GetComponent<InteractShopWindow>();
        if (!(GameObject.FindGameObjectsWithTag("LevelLogic").Length == 0))
        {
            Shop.myState = InteractShopWindow.ShopState.SecondLoad;
        }
        Shop.SetInteractMessage();*/
    }

    public enum ShopState
    {
        FirstLoad,
        SecondLoad,
        FinishedGame
    }
}

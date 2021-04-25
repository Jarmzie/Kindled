using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStateManager : MonoBehaviour
{
    public ShopState myState = ShopState.FirstLoad;
    public TutorialState myTutState = TutorialState.FirstLoad;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public enum ShopState
    {
        FirstLoad,
        SecondLoad,
        Default,
        ThirdLantern,
        FinishedGameInit,
        FinishedGame
    }

    public enum TutorialState
    {
        FirstLoad,
        GoodToGo
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStateManager : MonoBehaviour
{
    public ShopState myState = ShopState.FirstLoad;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public enum ShopState
    {
        FirstLoad,
        SecondLoad,
        FinishedGame
    }
}
